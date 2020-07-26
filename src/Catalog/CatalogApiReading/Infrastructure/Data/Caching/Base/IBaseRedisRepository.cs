using CatalogApiReading.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Caching.Base
{
    public interface IBaseRedisRepository
    {
        Task<RedisValue> Get(string key, int database, bool async = false);
        RedisValue[] Get(IReadOnlyCollection<string> keys, int database);
        Task<T> Get<T>(string key, int database, bool async);
        IEnumerable<T> Get<T>(IReadOnlyCollection<string> keys, int database);
        List<string> GetAllKeys(int database);
        bool Remove(string key, int database);
        void ClearAll(int database);
        bool Set(string key, object obj, int database);
        bool Set(string key, object obj, int database, TimeSpan expiry);
    }
}
