﻿namespace FootballLeagueApi.Services.Constants
{
    public static class ErrorMessages
    {
        public const string EntityDoesNotExist = @"{0} with {1} '{2}' does not exist!";
        public const string EntityAlreadyExists = @"{0} - '{1}' already exists!";
        public const string SameTeam = @"Home Team id and Away Team id should be different!";
    }
}
