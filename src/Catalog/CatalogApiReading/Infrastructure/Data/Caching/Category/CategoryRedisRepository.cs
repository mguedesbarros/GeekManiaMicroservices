using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.Base;
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
    public class CategoryRedisRepository : BaseRedisRepository, ICategoryRedisRepository
    {
        public CategoryRedisRepository(ICatalogRedisContext context)
            :base(context)
        {
        }        
    }
}
