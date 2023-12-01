namespace FootballLeagueApi.Data.Models.InputModels.Game
{
    public class EditGameModel
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
    }
}
