using CocQuery.Models.Coc;

namespace CocQuery.Services.Coc
{
    public class LocationsService
    {
        public LocationsService() { }

        public async Task<QueryResponseResult<QueryResult<ClanRankingList>>> GetClanRankingAsync(int locationId,int? limit,string? after,string? before)
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
                LocationId = locationId,
                Uri = $"locations/{locationId}/rankings/clans"
            };

            var data = await client.QueryAsync<QueryResponseResult<QueryResult<ClanRankingList>>>(request);
            return data;
        }

        public async Task<QueryResponseResult<QueryResult<PlayerRankingList>>> GetPlayerRankingAsync(int locationId, int? limit, string? after, string? before)
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
                LocationId = locationId,
                Uri = $"locations/{locationId}/rankings/players"
            };

            var data = await client.QueryAsync<QueryResponseResult<QueryResult<PlayerRankingList>>>(request);
            return data;
        }
    }
}
