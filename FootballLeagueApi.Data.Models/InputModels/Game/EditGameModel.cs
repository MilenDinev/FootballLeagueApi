namespace FootballLeagueApi.Data.Models.InputModels.Game
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class EditGameModel
    {
        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }

        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
        public int? HomeTeamGoals { get; set; }

        [Range(AttributeParams.MinGoals, 
            AttributeParams.MaxGoals, 
            ErrorMessage = ValidationMessages.MinMaxGoals)]
        public int? AwayTeamGoals { get; set; }
        public string PlayedOn { get; set; }
    }
}
