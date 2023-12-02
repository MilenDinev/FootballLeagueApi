namespace FootballLeagueApi.Data.Entities
{
    using System.Collections.Generic;
    using Base;

    public class Team : BaseEntity
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();  
            this.AwayGames = new HashSet<Game>();  
        }

        public string Name { get; set; }
        public string NormalizedTag { get; set; }
        public int Points { get; set; }
        public virtual ICollection<Game> HomeGames { get; set; }
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
