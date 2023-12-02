namespace FootballLeagueApi.Test
{
    using Xunit;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Services;
    using Services.Handlers;
    using Services.Interfaces;
    using Mocks;

    public class TeamServiceTests
    {
        [Fact]
        public async Task GetAllTeams_ValidData_ShouldSucceed()
        {
            //Arrange
            var teamService = await GetTeamServiceAsync();

            //Act
            var result = await teamService.GetAllTeamsAsync();

            //Assert
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<ICollection<TeamResponseModel>>(result);
            Assert.Equal(7, result.ToList().Count);
        }

        [Fact]
        public async Task GetTeamById_ValidData_ShouldSucceed()
        {
            //Arrange
            var teamService = await GetTeamServiceAsync();

            //Act
            var result = await teamService.GetTeamAsync(1);

            //Assert
            Assert.IsType<TeamResponseModel>(result);
            Assert.Equal("Levski", result.Name);
        }

        [Fact]
        public async Task GetTeamById_InvalidData_ThrowsException()
        {
            //Arrange
            var teamService = await GetTeamServiceAsync();

            //Act Assert
            ResourceNotFoundException exception = await Assert.ThrowsAsync<ResourceNotFoundException>(() => teamService.GetTeamAsync(9999));
            Assert.Equal("Team with id '9999' does not exists!", exception.Message);
        }

        [Fact]
        public async Task CreateTeam_InvalidData_ThrowsException()
        {
            //Arrange
            var teamService = await GetTeamServiceAsync();
            var teamCreateModel = new CreateTeamModel
            {
                Name = "Levski",
            };

            //Act Assert
            ResourceAlreadyExistsException exception = await Assert.ThrowsAsync<ResourceAlreadyExistsException>(() => teamService.CreateAsync(teamCreateModel));
            Assert.Equal("Team - 'Levski' already exists!", exception.Message);
        }

        private async Task<ITeamService> GetTeamServiceAsync()
        {
            var data = await GetDatabaseMockAsync();
            return new TeamService(data);
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

            return context;
        }
    }
}
