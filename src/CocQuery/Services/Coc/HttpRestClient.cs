using CocQuery.Models.Coc;
using Newtonsoft.Json;
using RestSharp;

namespace CocQuery.Services.Coc
{
    public class HttpRestClient
    {
        RestClient client;
        public HttpRestClient()
        {
            var address = new Uri("http://47.117.147.152:8081/");
            client = new RestClient(address);
            client.AddDefaultHeader("ContentType", "application/json");
        }
        public async Task<QueryResult<T>> QueryAsync<T>(BaseRequest request) where T : class
        {
            request.Uri = request.Uri + request.Query?.ToString();
            var data = await GetDataAsync(request);
            var deserializedData = JsonConvert.DeserializeObject<QueryResult<T>>(data);

            request.Query?.SetCursors(deserializedData.Paging.Cursors);

            return deserializedData;
        }

        public async Task<T> RequestAsync<T>(BaseRequest request) where T : class
        {
            var data = await GetDataAsync(request);
            var deserializedData = JsonConvert.DeserializeObject<T>(data);

            return deserializedData;
        }

        private async Task<string> GetDataAsync(BaseRequest request)
        {
            var response = request.Content == default ?
                await client.ExecuteAsync(new RestRequest(request.Uri, Method.Get)) :
                await client.ExecuteAsync(new RestRequest(request.Uri, Method.Post).AddStringBody(JsonConvert.SerializeObject(request.Content), DataFormat.Json));

            var content = response.Content;

            if (response.IsSuccessStatusCode)
                return content;

            try
            {
                var error = JsonConvert.DeserializeObject<CocErrorMessage>(content);
                throw new CocException(error);
            }
            catch (Exception ex) when (ex.GetType() != typeof(CocException))
            {
                var error = new CocErrorMessage
                {
                    Message = ex.Message,
                    Reason = content
                };

                throw new CocException(error);
            }
        }
    }
}
