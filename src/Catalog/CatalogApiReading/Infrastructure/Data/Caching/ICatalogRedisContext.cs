using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Caching
{
    public interface ICatalogRedisContext
    {
        IDatabase GetDatabase(int dataBase);
        IConnectionMultiplexer GetConnection();
    }
}
