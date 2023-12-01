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
                    Name = "Levski Sofia",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "CSKA Sofia",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Slavia",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Beroe",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Ludogorets",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Lokomotiv Plovdiv",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Lokomotiv Sofia",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Marek",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Botev Plovdiv",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

                new Team()
                {
                    Name = "Cherno More",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                },

            };

            await dbContext.Teams.AddRangeAsync(teams);
            await dbContext.SaveChangesAsync();
        }
    }
}

