namespace FootballLeagueApi.Data.Seeders
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Entities;

    internal class TeamsSeeder
    {
        internal static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var teams = new List<Team>()
            {
                new Team()
                {
                    Name = "Levski",
                    SearchTag = "Levski".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "CSKA",
                    SearchTag = "CSKA".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Slavia",
                    SearchTag = "Slavia".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Beroe",
                    SearchTag = "Beroe".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Ludogorets",
                    SearchTag = "Ludogorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Marek",
                    SearchTag = "Marek".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Chernomorets",
                    SearchTag = "Chernomorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

            };

            await dbContext.Teams.AddRangeAsync(teams);
            await dbContext.SaveChangesAsync();
        }
    }
}

