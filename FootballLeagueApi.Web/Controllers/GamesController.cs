namespace FootballLeagueApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Models.InputModels.Game;
    using Data.Models.ResponseModels.Game;
    using Services.Interfaces;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Create/")]
        public async Task<ActionResult> Create(CreateGameModel createGameModel)
        {
            await _gameService.CreateAsync(createGameModel);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponseModel>>> Get()
        {
            var gamesReponseModel = await _gameService.GetGameResponseModelBundleAsync();

            return gamesReponseModel.ToList();
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameResponseModel>> GetById(int gameId)
        {
            var gameReponseModel = await _gameService.GetGameResponseModelAsync(gameId);

            return gameReponseModel;
        }

        [HttpPut("Edit/{gameId}")]
        public async Task Edit(EditGameModel editGameModel, int gameId)
        {
            await _gameService.EditAsync(editGameModel, gameId);
        }

        [HttpDelete("Delete/{gameId}")]
        public async Task Delete(int gameId)
        {
            await _gameService.DeleteAsync(gameId);
        }
    }
}
