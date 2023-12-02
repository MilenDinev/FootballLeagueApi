namespace FootballLeagueApi.Services
{
    using Microsoft.Extensions.Caching.Memory;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Services.Constants;
    using Services.Interfaces;

    public class CachedTeamService : ITeamService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TeamService _teamService;

        public CachedTeamService(IMemoryCache memoryCache, TeamService teamService)
        {
            _memoryCache = memoryCache;
            _teamService = teamService;
        }

        public async Task CreateAsync(CreateTeamModel teamModel)
        {
            await _teamService.CreateAsync(teamModel);
        }

        public async Task DeleteAsync(int teamId)
        {
            await _teamService.DeleteAsync(teamId);
        }

        public async Task EditAsync(EditTeamModel teamModel, int teamId)
        {
            await _teamService.EditAsync(teamModel, teamId);

            var teamKey = ($"{CacheServiceParams.SingleTeamKey}", teamId);
            _memoryCache.Remove(teamKey);

            var groupKey = CacheServiceParams.TeamsGroupKey;
            _memoryCache.Remove(groupKey);
        }

        public async Task<TeamResponseModel> GetTeamAsync(int teamId)
        {
            var key = ($"{CacheServiceParams.SingleTeamKey}", teamId);

            var result = await _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(CacheServiceParams.defaultDurrotation);
                    return _teamService.GetTeamAsync(teamId);
                });

            return result;
        }

        public async Task<ICollection<TeamResponseModel>> GetAllTeamsAsync()
        {
            var key = CacheServiceParams.TeamsGroupKey;

            var result = await _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(CacheServiceParams.defaultDurrotation);
                    return _teamService.GetAllTeamsAsync();
                });

            return result;
        }

        public async Task<ICollection<TeamRankingResponseModel>> GetTeamsRankingAsync()
        {
            return await _teamService.GetTeamsRankingAsync();
        }
    }
}
