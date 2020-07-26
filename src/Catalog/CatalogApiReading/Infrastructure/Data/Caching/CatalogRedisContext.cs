using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Caching
{
    public class CatalogRedisContext : ICatalogRedisContext
    {
        private readonly ConnectionMultiplexer _redisConnection;
        
        public CatalogRedisContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
        }

        public IConnectionMultiplexer GetConnection() => this._redisConnection;

        public IDatabase GetDatabase(int dataBase)
        {
            if (_redisConnection != null && _redisConnection.IsConnected)
            {
                return _redisConnection.GetDatabase(dataBase);
            }            

            return _redisConnection.GetDatabase(dataBase); ;
        }
    }
}
