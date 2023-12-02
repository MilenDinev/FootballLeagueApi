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
                    NormalizedTag = "Levski".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "CSKA",
                    NormalizedTag = "CSKA".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Slavia",
                    NormalizedTag = "Slavia".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Beroe",
                    NormalizedTag = "Beroe".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Ludogorets",
                    NormalizedTag = "Ludogorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Marek",
                    NormalizedTag = "Marek".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Chernomorets",
                    NormalizedTag = "Chernomorets".ToUpper(),
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

            };

            await dbContext.Teams.AddRangeAsync(teams);
            await dbContext.SaveChangesAsync();
        }
    }
}

