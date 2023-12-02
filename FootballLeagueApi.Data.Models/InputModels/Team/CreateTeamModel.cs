namespace FootballLeagueApi.Data.Models.InputModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class CreateTeamModel
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        [StringLength(AttributeParams.TeamTitleMaxLength,
            ErrorMessage = ValidationMessages.MinMaxLength,
            MinimumLength = AttributeParams.TeamTitleMinLength)]
        public string Name { get; set; }
    }
}
