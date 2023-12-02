namespace FootballLeagueApi.Services.Handlers
{
    using System;

    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
