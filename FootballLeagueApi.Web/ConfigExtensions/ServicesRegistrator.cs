namespace FootballLeagueApi.Web.ConfigExtensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Data.Entities;
    using Data.Repository;
    using Services;
    using Services.Interfaces;

    public static class ServicesRegistrator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<Repository<Game>>();
            services.AddScoped<Repository<Team>>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IGameService, GameService>();
        }
    }
}
