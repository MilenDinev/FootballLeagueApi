namespace FootballLeagueApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data;
    using Data.Entities;
    using Data.Models.InputModels.Game;
    using Data.Models.ResponseModels.Game;
    using Handlers;
    using Constants;
    using Interfaces;

    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbContext;

        public GameService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CreateGameModel gameModel)
        {
            await ValidateInputAsync(gameModel.HomeTeamId, gameModel.AwayTeamId);

            var game = new Game
            {
                HomeTeamId = gameModel.HomeTeamId,
                AwayTeamId = gameModel.AwayTeamId,
                HomeTeamGoals = gameModel.HomeTeamGoals,
                AwayTeamGoals = gameModel.AwayTeamGoals,
                CreationDate = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow,
            };

            await _dbContext.Games.AddAsync(game);
            await UpdateTeamPointsAsync(gameModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int gameId)
        {
            var game = await _dbContext.Games
                .FirstOrDefaultAsync(game => game.Id == gameId && !game.IsDeleted)
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Game).Name, "id", gameId));

            game.IsDeleted = true;
            game.LastModifiedOn = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EditGameModel gameModel, int gameId)
        {
            var game = await _dbContext.Games
                .FirstOrDefaultAsync(game => game.Id == gameId && !game.IsDeleted)
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Game).Name, "id", gameId));

            await ValidateInputAsync(game.HomeTeamId, game.AwayTeamId);


            game.HomeTeamId = gameModel.HomeTeamId;
            game.AwayTeamId = gameModel.AwayTeamId;
            game.HomeTeamGoals = gameModel.HomeTeamGoals;
            game.AwayTeamGoals = gameModel.AwayTeamGoals;

            game.LastModifiedOn = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<GameResponseModel> GetGameAsync(int gameId)
        {
            var gameResponseModel = await _dbContext.Games
                .Where(game => game.Id == gameId && !game.IsDeleted)
                .Select(game => new GameResponseModel
                {
                    HomeTeam = game.HomeTeam.Name,
                    AwayTeam = game.AwayTeam.Name,
                    Result = ($"{game.HomeTeamGoals} : {game.AwayTeamGoals}"),
                    PlayedOn = game.CreationDate.ToString("f")
                })
                .FirstOrDefaultAsync()
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Game).Name, "id", gameId));

            return gameResponseModel;
        }

        public async Task<ICollection<GameResponseModel>> GetAllGamesAsync()
        {
            var gamesReponseModel = await _dbContext.Games
                .Where(game => !game.IsDeleted)
                .Select(game => new GameResponseModel
                {
                    Id = game.Id,
                    HomeTeam = game.HomeTeam.Name,
                    AwayTeam = game.AwayTeam.Name,
                    Result = ($"{game.HomeTeamGoals} : {game.AwayTeamGoals}"),
                    PlayedOn = game.CreationDate.ToString("f"),

                }).ToListAsync();

            return gamesReponseModel;
        }

        private async Task ValidateInputAsync(int homeTeamId, int awayTeamId)
        {
            if (homeTeamId == awayTeamId)
                throw new ArgumentException(string.Format(
                    ErrorMessages.SameTeam));

            var isHomeTeamExists = await _dbContext.Teams.AnyAsync(team => team.Id == homeTeamId && !team.IsDeleted);

            if (!isHomeTeamExists)
                throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Team).Name, "id", homeTeamId));

            var isAwayTeamExists = await _dbContext.Teams.AnyAsync(team => team.Id == awayTeamId && !team.IsDeleted);

            if (!isAwayTeamExists)
                throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Team).Name, "id", awayTeamId));
        }

        private async Task UpdateTeamPointsAsync(CreateGameModel gameModel)
        {
            var homeTeam = await _dbContext.Teams.FindAsync(gameModel.HomeTeamId);
            var awayTeam = await _dbContext.Teams.FindAsync(gameModel.AwayTeamId);

            UpdatePoints(homeTeam, awayTeam, gameModel.HomeTeamGoals, gameModel.AwayTeamGoals);
        }

        private void UpdatePoints(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
        {
            if (homeGoals > awayGoals)
            {
                homeTeam.Points += GamePoints.Win;
            }
            else if (homeGoals == awayGoals)
            {
                homeTeam.Points += GamePoints.Draw;
                awayTeam.Points += GamePoints.Draw;
            }
            else
            {
                awayTeam.Points += GamePoints.Win;
            }

            homeTeam.LastModifiedOn = DateTime.UtcNow;
            awayTeam.LastModifiedOn = DateTime.UtcNow;
        }
    }
}
