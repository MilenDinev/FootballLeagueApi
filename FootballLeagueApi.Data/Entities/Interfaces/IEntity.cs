using System;

namespace FootballLeagueApi.Data.Entities.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime LastModifiedOn { get; set; }
        bool IsDeleted { get; set; }
    }
}
