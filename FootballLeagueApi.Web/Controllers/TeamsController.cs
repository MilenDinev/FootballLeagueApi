﻿namespace FootballLeagueApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Models.InputModels.Team;
    using Data.Models.ResponseModels.Team;
    using Services.Interfaces;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("Create/")]
        public async Task<ActionResult> Create(CreateTeamModel createTeamModel)
        {
            await _teamService.CreateAsync(createTeamModel);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamResponseModel>>> Get()
        {
            var teamsResponseModel = await _teamService.GetTeamResponseModelBundleAsync();

            return teamsResponseModel.ToList();
        }

        [HttpGet("Ranking/")]
        public async Task<ActionResult<IEnumerable<TeamResponseModel>>> GetRanked()
        {
            var teamsRanking = await _teamService.GetTeamsRankingAsync();

            return teamsRanking.ToList();
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamResponseModel>> GetById(int teamId)
        {
            var teamReponseModel = await _teamService.GetTeamResponseModelAsync(teamId);

            return teamReponseModel;
        }

        [HttpPut("Edit/{teamId}")]
        public async Task Edit(EditTeamModel editTeamModel, int teamId)
        {
            await _teamService.EditAsync(editTeamModel, teamId);
        }

        [HttpDelete("Delete/{teamId}")]
        public async Task Delete(int teamId)
        {
            await _teamService.DeleteAsync(teamId);
        }
    }
}
