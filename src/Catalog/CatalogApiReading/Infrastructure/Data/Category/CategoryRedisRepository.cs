using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Category
{
    public class CategoryRedisRepository : ICategoryRedisRepository
    {
        private readonly IDistributedCache _cache;
        public CategoryRedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void Add(IList<Models.Category> categories)
        {
            string serializeObject = JsonConvert.SerializeObject(categories);
            byte[] data = Encoding.UTF8.GetBytes(serializeObject);

            var key = $"categories";            

            _cache.Set(key, data);
        }

        public void Add(Models.Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            var key = $"categories";

            _cache.Remove(key);
        }

        public async Task<IList<Models.Category>> GetCategories()
        {
            var categories = new List<Models.Category>();
            var key = $"categories";

            byte[] data = await _cache.GetAsync(key);

            if (data != null)
            {
                var json = Encoding.UTF8.GetString(data);

                categories = JsonConvert.DeserializeObject<List<Models.Category>>(json);
            }

            return categories;
        }
    }
}
