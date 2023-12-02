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
            services.AddMemoryCache();
            services.AddScoped<TeamService>();
            services.AddScoped<ITeamService, CachedTeamService>();
            services.AddScoped<IGameService, GameService>();
        }
    }
}
