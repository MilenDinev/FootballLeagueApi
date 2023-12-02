namespace FootballLeagueApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data;
    using Data.Entities;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Handlers;
    using Constants;
    using Interfaces;

    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CreateTeamModel teamModel)
        {
            await ValidateCreateInputAsync(teamModel.Name);

            var team = new Team
            {
                Name = teamModel.Name,
                CreationDate = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow,
                SearchTag = teamModel.Name.ToUpper(),
            };

            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EditTeamModel teamModel, int teamId)
        {
            var team = await _dbContext.Teams
                .FirstOrDefaultAsync(team => team.Id == teamId && !team.IsDeleted)
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Team).Name, "id", teamId));

            team.Name = teamModel.Name != team.Name ? teamModel.Name : team.Name;

            team.LastModifiedOn = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int teamId)
        {
            var team = await _dbContext.Teams
                .FirstOrDefaultAsync(team => team.Id == teamId && !team.IsDeleted)
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Team).Name, "id", teamId));

            team.IsDeleted = true;

            team.LastModifiedOn = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TeamResponseModel> GetTeamAsync(int teamId)
        {
            var teamResponseModel = await _dbContext.Teams
                .Where(team => team.Id == teamId && !team.IsDeleted)
                .Select(team => new TeamResponseModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    Points = team.Points,
                })
                .FirstOrDefaultAsync()
                ?? throw new ResourceNotFoundException(string.Format(
                    ErrorMessages.EntityDoesNotExist,
                    typeof(Team).Name, "id", teamId));

            return teamResponseModel;
        }

        public async Task<ICollection<TeamRankingResponseModel>> GetTeamsRankingAsync()
        {
            var teamsRanking = await _dbContext.Teams
                .Where(team => !team.IsDeleted)
                .Select(team => new TeamRankingResponseModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    Points = team.Points,
                    HomeGamesPlayed = team.HomeGames.Count(),
                    AwayGamesPlayed = team.AwayGames.Count(),
                    GamesWon = team.HomeGames.Count(x => x.HomeTeamGoals > x.AwayTeamGoals) +
                       team.AwayGames.Count(x => x.AwayTeamGoals > x.HomeTeamGoals),
                    GamesDraw = team.HomeGames.Count(x => x.HomeTeamGoals == x.AwayTeamGoals) +
                        team.AwayGames.Count(x => x.AwayTeamGoals == x.HomeTeamGoals),
                    GamesLost = team.HomeGames.Count(x => x.HomeTeamGoals < x.AwayTeamGoals) +
                        team.AwayGames.Count(x => x.AwayTeamGoals < x.HomeTeamGoals),
                    TotalGamesPlayed = team.HomeGames.Count() + team.AwayGames.Count(),
                    TotalGoalScored = team.HomeGames.Sum(x => x.HomeTeamGoals) +
                            team.AwayGames.Sum(x => x.AwayTeamGoals),
                })
                 .OrderByDescending(team => team.Points)
                 .ThenBy(team => team.TotalGoalScored)
                 .ThenBy(team => team.GamesWon)
                 .ThenBy(team => team.GamesDraw)
                 .ToListAsync();

            teamsRanking = teamsRanking.Select((team, index) =>
            {
                team.Rank = index + 1; // Adding 1 because index starts at 0
                return team;

            }).ToList();

            return teamsRanking;
        }

        public async Task<ICollection<TeamResponseModel>> GetAllTeamsAsync()
        {
            var teamsResponseModel = await _dbContext.Teams
                .Where(team => !team.IsDeleted)
                .Select(team => new TeamResponseModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    Points = team.Points,
                })
                 .ToListAsync();

            return teamsResponseModel;
        }

        private async Task ValidateCreateInputAsync(string searchTag)
        {
            var isAny = await _dbContext.Teams
                .AnyAsync(team => team.SearchTag == searchTag.ToUpper() && !team.IsDeleted);

            if (isAny)
                throw new ResourceAlreadyExistsException(string.Format(
                    ErrorMessages.EntityAlreadyExists,
                    typeof(Team).Name, searchTag));
        }
    }
}
