namespace FootballLeagueApi.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;

    public interface ITeamService
    {
        Task CreateAsync(CreateTeamModel teamModel);
        Task EditAsync(EditTeamModel teamModel, int teamId);
        Task DeleteAsync(int teamId);
        Task<ICollection<TeamResponseModel>> GetTeamResponseModelBundleAsync();
    }
}