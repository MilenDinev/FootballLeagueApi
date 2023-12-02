namespace FootballLeagueApi.Data.Models.InputModels.Game
{
    public class EditGameModel
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
    }
}
