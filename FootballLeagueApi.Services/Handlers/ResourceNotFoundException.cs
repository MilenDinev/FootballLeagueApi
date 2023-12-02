namespace FootballLeagueApi.Services.Handlers
{
    using System;

    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {
        }
    }
}
