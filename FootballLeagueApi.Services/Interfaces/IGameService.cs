namespace FootballLeagueApi.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Models.InputModels.Game;
    using Data.Models.ResponseModels.Game;

    public interface IGameService
    {
        Task CreateAsync(CreateGameModel gameModel);
        Task EditAsync(EditGameModel gameModel, int gameId);
        Task DeleteAsync(int gameId);
        Task<GameResponseModel> GetGameAsync(int gameId);
        Task<ICollection<GameResponseModel>> GetAllGamesAsync();
    }
}
