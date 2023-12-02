namespace FootballLeagueApi.Test
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using Xunit;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Data.Models.InputModels.Game;
    using Data.Models.ResponseModels.Game;
    using Services;
    using Services.Handlers;
    using Services.Interfaces;
    using Mocks;

    public class GameServiceTests
    {
        [Fact]
        public async Task GetAllGames_ValidData_ShouldSucceed()
        {
            //Arrange
            var gameService = await GetGameServiceAsync();

            //Act
            var result = await gameService.GetAllGamesAsync();

            //Assert
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<ICollection<GameResponseModel>>(result);
            Assert.Equal(7, result.ToList().Count);
        }

        [Fact]
        public async Task GetGameById_ValidData_ShouldSucceed()
        {
            //Arrange
            var gameService = await GetGameServiceAsync();

            //Act
            var result = await gameService.GetGameAsync(1);

            //Assert
            Assert.IsType<GameResponseModel>(result);
            Assert.Equal("Levski", result.HomeTeam);
            Assert.Equal("CSKA", result.AwayTeam);
            Assert.Equal("2 : 1", result.Result);
        }

        [Fact]
        public async Task GetGameById_InvalidData_ThrowsException()
        {
            //Arrange
            var gameService = await GetGameServiceAsync();

            //Act Assert
            ResourceNotFoundException exception = await Assert.ThrowsAsync<ResourceNotFoundException>(() => gameService.GetGameAsync(9999));
            Assert.Equal("Game with id '9999' does not exists!", exception.Message);
        }

        [Fact]
        public async Task CreateGame_InvalidData_ThrowsException()
        {
            //Arrange
            var gameService = await GetGameServiceAsync();
            var gameCreateModel = new CreateGameModel
            {
                HomeTeamId = 1,
                AwayTeamId = 1,
            };

            //Act Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => gameService.CreateAsync(gameCreateModel));
            Assert.Equal("Home Team id and Away Team id should be different!", exception.Message);
        }

        private async Task<IGameService> GetGameServiceAsync()
        {
            var data = await GetDatabaseMockAsync();
            return new GameService(data);
        }

        private async Task<ApplicationDbContext> GetDatabaseMockAsync()
        {
            var context = DatabaseMock.Instance;

            var teams = new List<Team>()
            {
                new Team()
                {
                    Name = "Levski",
                    SearchTag = "Levski".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 3,
                },

                new Team()
                {
                    Name = "CSKA",
                    SearchTag = "CSKA".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 5,
                },

                new Team()
                {
                    Name = "Slavia",
                    SearchTag = "Slavia".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 2,
                },

                new Team()
                {
                    Name = "Beroe",
                    SearchTag = "Beroe".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 16,

                },

                new Team()
                {
                    Name = "Ludogorets",
                    SearchTag = "Ludogorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 1,
                },

                new Team()
                {
                    Name = "Marek",
                    SearchTag = "Marek".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 12,
                },

                new Team()
                {
                    Name = "Chernomorets",
                    SearchTag = "Chernomorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow,
                    Points = 7,
                },

            };

            await context.Teams.AddRangeAsync(teams);
            await context.SaveChangesAsync();


            var games = new List<Game>()
            {
                new Game()
                {
                    HomeTeamId= 1,
                    AwayTeamId= 2,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 1,              
                },

                new Game()
                {
                    HomeTeamId= 3,
                    AwayTeamId= 1,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 2,
                },

                new Game()
                {
                    HomeTeamId= 5,
                    AwayTeamId= 4,
                    HomeTeamGoals = 1,
                    AwayTeamGoals = 2,
                },

                new Game()
                {
                    HomeTeamId= 5,
                    AwayTeamId= 2,
                    HomeTeamGoals = 1,
                    AwayTeamGoals = 1,
                },

                new Game()
                {
                    HomeTeamId= 3,
                    AwayTeamId= 1,
                    HomeTeamGoals = 2,
                    AwayTeamGoals = 4,
                },

                new Game()
                {
                    HomeTeamId= 7,
                    AwayTeamId= 1,
                    HomeTeamGoals = 0,
                    AwayTeamGoals = 1,
                },

                new Game()
                {
                    HomeTeamId= 3,
                    AwayTeamId= 2,
                    HomeTeamGoals = 1,
                    AwayTeamGoals = 1,
                },

            };

            await context.Games.AddRangeAsync(games);
            await context.SaveChangesAsync();

            return context;
        }
    }
}

