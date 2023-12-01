namespace FootballLeagueApi.Data.Models.ResponseModels.Game
{
    public class GameResponseModel
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Result { get; set; }
        public string PlayedOn { get; set; }
    }
}
