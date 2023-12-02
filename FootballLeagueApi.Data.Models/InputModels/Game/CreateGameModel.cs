namespace FootballLeagueApi.Data.Models.InputModels.Game
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Constants;

    public class CreateGameModel
    {
        [Range(AttributeParams.IdMin, 
            int.MaxValue, 
            ErrorMessage = ValidationMessages.ValidNumber)]
        public int HomeTeamId { get; set; }

        [Range(AttributeParams.IdMin, 
            int.MaxValue, 
            ErrorMessage = ValidationMessages.ValidNumber)]
        public int AwayTeamId { get; set; }

        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
        public int HomeTeamGoals { get; set; }

        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
        public int AwayTeamGoals { get; set; }
    }
}
