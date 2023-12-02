using FootballLeagueApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeagueApi.Services.Constants
{
    public static class CacheServiceParams
    {
        public const string SingleTeamKey = @"team-cache-key-for-team-{0}";
        public const string TeamsGroupKey = @"teams-group-cache-key-for-group";
        public static TimeSpan defaultDurrotation =  TimeSpan.FromMinutes(5);
    }
}
