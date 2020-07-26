using CatalogApiReading.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Caching.Base
{
    public class BaseRedisRepository : IBaseRedisRepository
    {
        private readonly ICatalogRedisContext _context;
        private readonly IConnectionMultiplexer _connection;

        public BaseRedisRepository(ICatalogRedisContext context)
        {
            _context = context;
            _connection = _context.GetConnection();
        }

        public void ClearAll(int database)
        {
            var endpoints = _connection.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                _connection.GetServer(endpoint).FlushDatabase(database);
            }
        }

        public async Task<RedisValue> Get(string key, int database, bool async = false)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) return RedisValue.Null;

            try
            {
                if (async)
                    return await _context.GetDatabase(database).StringGetAsync(key);
                else
                    return _context.GetDatabase(database).StringGet(key);
            }
            catch
            {
                return RedisValue.Null;
            }
        }

        public RedisValue[] Get(IReadOnlyCollection<string> keys, int database)
        {
            if (keys == null || keys.Count < 1) return new RedisValue[0];

            var i = 0;
            var redisKeys = new RedisKey[keys.Count];
            foreach (var key in keys)
            {
                redisKeys[i] = key;
                i++;
            }

            return _context.GetDatabase(database).StringGet(redisKeys);
        }

        public async Task<T> Get<T>(string key, int database, bool async)
        {
            var obj = await Get(key, database, async);
            return obj.HasValue ? JsonConvert.DeserializeObject<T>(obj) : default(T);
        }

        public IEnumerable<T> Get<T>(IReadOnlyCollection<string> keys, int database)
        {
            var objs = Get(keys, database);
            return objs.Any()
                ? objs.Where(o => o.HasValue).Select(o => JsonConvert.DeserializeObject<T>(o)).ToList()
                : new List<T>();
        }

        public List<string> GetAllKeys(int database)
        {
            var r = new List<string>();
            var endpoints = _connection.GetEndPoints(true);

            foreach (var endpoint in endpoints)
            {
                var keys = _connection.GetServer(endpoint).Keys(database, "*").ToArray();
                if (keys.Any()) r.AddRange(keys.Select(redisKey => redisKey.ToString()));
            }

            return r;
        }

        public bool Remove(string key, int database)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) return false;
            return _context.GetDatabase(database).KeyDelete(key);
        }

        public bool Set(string key, object obj, int database)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) return false;
            if (obj == null) return Remove(key, database);

            var str = JsonConvert.SerializeObject(obj);
            return _context.GetDatabase(database).StringSet(key, str);
        }

        public bool Set(string key, object obj, int database, TimeSpan expiry)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) return false;
            if (obj == null) return Remove(key, database);

            var str = JsonConvert.SerializeObject(obj);
            return _context.GetDatabase(database).StringSet(key, str, expiry);
        }        
    }
}
