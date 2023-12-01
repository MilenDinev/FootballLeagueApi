namespace FootballLeagueApi.Data.Seeders
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;
    using FootballLeagueApi.Data.Repository;

    [ExcludeFromCodeCoverage]
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider applicationServices)
        {
            if (applicationServices == null)
            {
                throw new ArgumentNullException(nameof(applicationServices));
            }

            using (var serviceScope = applicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var teamRepository = serviceScope.ServiceProvider.GetRequiredService<Repository<Team>>();

                await MigrateDatabaseAsync(context);

                if (!await context.Teams.AnyAsync())
                {
                    await SeedDatabaseAsync(context);
                }
            }
        }

        private static async Task MigrateDatabaseAsync(ApplicationDbContext context)
        {
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await context.Database.MigrateAsync();
            }
        }

        private static async Task SeedDatabaseAsync(ApplicationDbContext context)
        {
            await TeamsSeeder.SeedAsync(context);
        }
    }
}
