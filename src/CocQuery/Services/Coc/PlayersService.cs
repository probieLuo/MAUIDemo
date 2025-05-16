using CocQuery.Models.Coc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocQuery.Services.Coc
{
    public class PlayersService
    {
        public PlayersService() { }

        public async Task<BaseResponseResult<Player>> GetPlayerAsync(string playerTag)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest
            {
                Uri = $"/players/{playerTag}",
                PlayerTag = playerTag
            };
            BaseResponseResult<Player> responseResult = await client.RequestAsync<BaseResponseResult<Player>>(request);
            return responseResult;
        }
       
    }
}
