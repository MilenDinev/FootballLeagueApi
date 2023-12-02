namespace FootballLeagueApi.Data.Models.InputModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class EditTeamModel
    {
        [StringLength(AttributeParams.TeamTitleMaxLength,
            ErrorMessage = ValidationMessages.MinMaxLength,
            MinimumLength = AttributeParams.TeamTitleMinLength)]
        public string Name { get; set; }
    }
}
