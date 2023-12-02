namespace FootballLeagueApi.Data.Entities
{
    using System;
    using Base;

    public class Game : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime PlayedOn { get; set; }
    }
}