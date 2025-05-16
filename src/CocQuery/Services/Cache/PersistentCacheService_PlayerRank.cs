using CocQuery.Models.Coc;
using Newtonsoft.Json;

namespace CocQuery.Services.Cache
{
    internal class PersistentCacheService_PlayerRank
    {
        private string CacheFilePath = "cache_PlayerRank.json";
        private string CacheKey = "";
        private string LocationId = "";
        public PersistentCacheService_PlayerRank(string locationId)
        {
            LocationId = locationId;
            // 设置缓存文件路径
            CacheFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            CacheFilePath = Path.Combine(CacheFilePath, $"cache_PlayerRank_{locationId}.json");
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"cache")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"cache"));
            }
        }

        // 获取缓存中的集合
        public async Task<PlayerRankingList> GetCollection()
        {
            // 检查缓存文件是否存在
            if (File.Exists(CacheFilePath))
            {
                // 读取缓存文件
                var cacheData = File.ReadAllText(CacheFilePath);
                var cache = JsonConvert.DeserializeObject<CacheData_PlayerRank>(cacheData);

                // 检查缓存是否过期
                if (cache != null && cache.Expiration.Date == DateTime.Now.Date)
                {
                    if (cache.Collection==null || cache.Collection.Count==0)
                    {
                        await RefreshCache();
                        var cacheData1 = File.ReadAllText(CacheFilePath);
                        var cache1 = JsonConvert.DeserializeObject<CacheData_PlayerRank>(cacheData);

                        return cache1.Collection;
                    }
                    return cache.Collection;
                }
                else
                {
                    // 如果缓存过期，刷新缓存
                    await RefreshCache();
                    var cacheData1 = File.ReadAllText(CacheFilePath);
                    var cache1 = JsonConvert.DeserializeObject<CacheData_PlayerRank>(cacheData);

                    return cache1.Collection;
                }
            }
            else
            {
                await RefreshCache();
                var cacheData = File.ReadAllText(CacheFilePath);
                var cache = JsonConvert.DeserializeObject<CacheData_PlayerRank>(cacheData);

                return cache.Collection;
            }

        }

        // 更新缓存中的集合
        private async Task UpdateCollection(PlayerRankingList newCollection)
        {
            // 设置缓存的过期时间为1天
            var expiration = DateTime.Now;

            // 创建缓存数据对象
            var cacheData = new CacheData_PlayerRank
            {
                Collection = newCollection,
                Expiration = expiration
            };

            // 将缓存数据序列化并写入文件
            var cacheJson = JsonConvert.SerializeObject(cacheData);
            await File.WriteAllTextAsync(CacheFilePath, cacheJson);
        }

        // 刷新缓存
        public async Task RefreshCache()
        {
            // 可以在这里重新获取数据并更新缓存
            // 示例：从数据库或其他数据源获取数据
            var newData = await GetNewDataFromDataSource();
            await UpdateCollection(newData);
        }

        // 从数据源获取数据
        private async Task<PlayerRankingList> GetNewDataFromDataSource()
        {
            Services.Coc.LocationsService locationsService = new Services.Coc.LocationsService();
            #region 过滤条件
            int locationId = 32000056;
            int? limit = 200;
            string? after = null;
            string? before = null;
            if (int.TryParse(LocationId, out int l))
            {
                locationId = l;
            }
            #endregion
            var responseResult = await locationsService.GetPlayerRankingAsync(locationId, limit, after, before);

            if (responseResult != null && responseResult.Data != null && responseResult.Data.Items != null)
            {
                return responseResult.Data.Items;
            }
            return new PlayerRankingList();
        }
    }

    // 缓存数据类
    public class CacheData_PlayerRank
    {
        public PlayerRankingList Collection { get; set; }
        public DateTime Expiration { get; set; }
    }
}