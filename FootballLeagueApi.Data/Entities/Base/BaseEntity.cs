namespace FootballLeagueApi.Data.Entities.Base
{
    using System;
    using Interfaces;

    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
