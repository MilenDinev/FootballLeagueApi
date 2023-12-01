namespace FootballLeagueApi.Data.Models.InputModels.Game
{
    public class CreateGameModel
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
    }
}
