namespace FootballLeagueApi.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Entities;
    using Data.Repository;
    using Data.Models.InputModels.Game;
    using Data.Models.ResponseModels.Game;
    using Interfaces;

    public class GameService : IGameService
    {
        private readonly Repository<Game> _repository;

        public GameService(Repository<Game> repository)
        {
            _repository = repository;
        }

        public Task CreateAsync(CreateGameModel gameModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int gameId)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAsync(EditGameModel gameModel, int gameId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<GameResponseModel>> GetGameResponseModelBundleAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
