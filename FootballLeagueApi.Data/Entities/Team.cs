namespace FootballLeagueApi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Team : IEntity
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();  
            this.AwayGames = new HashSet<Game>();  
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Game> HomeGames { get; set; }
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}
