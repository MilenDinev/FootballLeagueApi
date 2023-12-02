namespace FootballLeagueApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [Authorize]
        [HttpPost("Create/")]
        public async Task<ActionResult> Create(CreateTeamModel createTeamModel)
        {
            await _teamService.CreateAsync(createTeamModel);
            return CreatedAtAction(nameof(Get), "Successfully created!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResponseModel>>> Get()
        {
            var teamsResponseModel = await _teamService.GetAllTeamsAsync();

            return teamsResponseModel.ToList();
        }

        [HttpGet("Ranking/")]
        public async Task<ActionResult<IEnumerable<TeamRankingResponseModel>>> GetRanked()
        {
            var teamsRanking = await _teamService.GetTeamsRankingAsync();

            return teamsRanking.ToList();
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamResponseModel>> GetById(int teamId)
        {
            var teamReponseModel = await _teamService.GetTeamAsync(teamId);

            return teamReponseModel;
        }

        [Authorize]
        [HttpPut("Edit/{teamId}")]
        public async Task<ActionResult> Edit(EditTeamModel editTeamModel, int teamId)
        {
            await _teamService.EditAsync(editTeamModel, teamId);

            return Ok();
        }

        [HttpDelete("Delete/{teamId}")]
        public async Task Delete(int teamId)
        {
            await _teamService.DeleteAsync(teamId);
        }
    }
}
