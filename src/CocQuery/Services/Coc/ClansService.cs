using CocQuery.Models.Coc;

namespace CocQuery.Services.Coc
{
    public class ClansService
    {
        public ClansService() { }

        public async Task<BaseResponseResult<Clan>> GetClanAsync(string clanTag)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Uri = $"clans/{clanTag}",
                ClanTag = clanTag
            };
            BaseResponseResult<Clan> responseResult = await client.RequestAsync<BaseResponseResult<Clan>>(request);
            return responseResult;
        }

        public async Task<QueryResponseResult<QueryResult<ClanList>>> GetClansAsync(string? name, string? warFrequency, int? locationId, int? minMembers, int? maxMembers, int? minClanPoints, int? minClanLevel, int? limit, string? after, string? before, string? labelIds)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Uri = "clans",
                QueryClans = new QueryClans()
                {
                    Name = name,
                    WarFrequency = string.IsNullOrEmpty(warFrequency) ? null : (WarFrequency)Enum.Parse(typeof(WarFrequency), warFrequency),
                    LocationId = locationId,
                    MinMembers = minMembers,
                    MaxMembers = maxMembers,
                    MinClanPoints = minClanPoints,
                    MinClanLevel = minClanLevel,
                    LabelIds = labelIds,
                    Limit = limit,
                    After = after,
                    Before = before
                },
            };

            var data = await client.QueryClansAsync<QueryResponseResult<QueryResult<ClanList>>>(request);
            return data;
        }
        /*
        public async Task<BaseResponseResult<CurrentWarLeagueGroup>> GetCurrentWarLeagueGroupAsync(string clanTag)
        {
            HttpRestClient httpRestClient = new HttpRestClient();

            var request = new BaseRequest
            {
                Uri = $"clans/{clanTag}/currentwar/leaguegroup",
                ClanTag = clanTag
            };
            var data = await httpRestClient.RequestAsync<CurrentWarLeagueGroup>(request);
            return BaseResponseResult<CurrentWarLeagueGroup>.SuccessResult(data);
        }

        public async Task<BaseResponseResult<ClanWarLeagueWar>> GetClanWarLeagueWarAsync(string warTag)
        {
            HttpRestClient client = new HttpRestClient();

            var request = new BaseRequest
            {
                Uri = $"clans/clanwarleagues/wars/{warTag}",
                WarTag = warTag
            };
            var data = await client.RequestAsync<ClanWarLeagueWar>(request);
            return BaseResponseResult<ClanWarLeagueWar>.SuccessResult(data);
        }
        public async Task<QueryResponseResult<QueryResult<ClanWarLog>>> GetClanWarLogAsync(string clanTag, int? limit, string? after, string? before)
        {
            HttpRestClient client = new HttpRestClient();

            var request = new BaseRequest
            {
                Uri = $"clans/{clanTag}/warlog",
                Query = new Query()
                {
                    Limit = limit,
                    After = after,
                    Before = before
                },
            };
            QueryResult<ClanWarLog> data = await client.QueryAsync<ClanWarLog>(request);
            return QueryResponseResult<QueryResult<ClanWarLog>>.SuccessResult(data);
        }

        
        public async Task<BaseResponseResult<ClanWar>> GetCurrentWarAsync(string clanTag)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Uri = $"clans/{clanTag}/currentwar",
                ClanTag = clanTag
            };
            var data = await client.RequestAsync<ClanWar>(request);
            return BaseResponseResult<ClanWar>.SuccessResult(data);
        }

        public async Task<QueryResponseResult<QueryResult<ClanMemberList>>> GetClanMembersAsync(string clanTag, int? limit, string? after, string? before)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Query = new Query()
                {
                    Limit = limit,
                    After = after,
                    Before = before
                },
                Uri = $"clans/{clanTag}/members",
                ClanTag = clanTag
            };
            QueryResult<ClanMemberList> data = await client.QueryAsync<ClanMemberList>(request);
            return QueryResponseResult<QueryResult<ClanMemberList>>.SuccessResult(data);
        }
        public async Task<QueryResponseResult<QueryResult<ClanCapitalRaidSeasons>>> GetCapitalRaidSeasonsAsync(string clanTag, int? limit, string? after, string? before)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Query = new Query()
                {
                    Limit = limit,
                    After = after,
                    Before = before
                },
                Uri = $"clans/{clanTag}/capitalraidseasons",
                ClanTag = clanTag
            };
            QueryResult<ClanCapitalRaidSeasons> data = await client.QueryAsync<ClanCapitalRaidSeasons>(request);
            return QueryResponseResult<QueryResult<ClanCapitalRaidSeasons>>.SuccessResult(data);
        }
        */
    }
}
