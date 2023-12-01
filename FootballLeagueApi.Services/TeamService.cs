namespace FootballLeagueApi.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Entities;
    using Data.Repository;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Interfaces;

    public class TeamService : ITeamService
    {
        private readonly Repository<Team> _repository;

        public TeamService(Repository<Team> repository)
        {
            _repository = repository;
        }

        public Task CreateAsync(CreateTeamModel teamModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int teamId)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAsync(EditTeamModel teamModel, int teamId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<TeamResponseModel>> GetTeamResponseModelBundleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
