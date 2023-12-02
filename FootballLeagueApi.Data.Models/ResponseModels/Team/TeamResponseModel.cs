namespace FootballLeagueApi.Data.Models.ResponseModels.Team
{
    public class TeamResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int HomeGamesPlayed { get; set; }
        public int AwayGamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int GamesDraw { get; set; }
        public int TotalGoalScored { get; set; }
    }
}
