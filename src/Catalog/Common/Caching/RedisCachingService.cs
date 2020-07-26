using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Caching
{
    public static class RedisCachingService
    {
        //public static bool Set(string key, object obj, RedisBase database)
        //{
        //    try
        //    {
        //        return RedisService.Instance.Set(key, obj, (int)database);
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Exception em EABR.FSM.Infra.Cross.RedisCachingService.Set(3 params)", $"{ex.Message} | {ex.InnerException?.Message}", EventLogEntryType.Error);
        //    }

        //    return false;
        //}

        //public static bool Set(string key, object obj, RedisBase database, TimeSpan expiry)
        //{
        //    try
        //    {
        //        return RedisService.Instance.Set(key, obj, (int)database, expiry);
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Exception em EABR.FSM.Infra.Cross.RedisCachingService.Set(3 params)", $"{ex.Message} | {ex.InnerException?.Message}", EventLogEntryType.Error);
        //    }

        //    return false;
        //}

        //public static bool Set(string key, object obj, int cacheDuration, RedisBase database, bool useAsync = false)
        //{
        //    try
        //    {
        //        return RedisService.Instance.Set(key, obj, cacheDuration, (int)database, useAsync);
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("Exception em EABR.FSM.Infra.Cross.RedisCachingService.Set(5 params)", $"{ex.Message} | {ex.InnerException?.Message}", EventLogEntryType.Error);
        //    }

        //    return false;
        //}

        //public static T Get<T>(string key, RedisBase database, bool async = false)
        //{
        //    return RedisService.Instance.Get<T>(key, (int)database, async);
        //}

        //public static IEnumerable<T> Get<T>(IReadOnlyCollection<string> keys, RedisBase database)
        //{
        //    return RedisService.Instance.Get<T>(keys, (int)database);
        //}

        //public static bool Remove(string key, RedisBase database)
        //{
        //    return RedisService.Instance.Remove(key, (int)database);
        //}

        //public static bool HasValue(string key, RedisBase database)
        //{
        //    return RedisService.Instance.HasValue(key, (int)database);
        //}

        //public static List<string> GetAllKeys(RedisBase database)
        //{
        //    return RedisService.Instance.GetAllKeys((int)database);
        //}

        //public static bool Lock(string key, string token, RedisBase database)
        //{
        //    return RedisService.Instance.Lock(key, token, (int)database);
        //}

        //public static bool Lock(string key, string token, TimeSpan expiry, int database)
        //{
        //    return RedisService.Instance.Lock(key, token, expiry, (int)database);
        //}

        //public static bool Unlock(string key, string token, RedisBase database)
        //{
        //    return RedisService.Instance.Unlock(key, token, (int)database);
        //}

        //public static bool ExecuteWithLock(Action callback, string keyLocked, string keyNameLock, TimeSpan expiry, RedisBase database)
        //{
        //    var executed = RedisService.Instance.ExecuteWithLock(callback, keyLocked, keyNameLock, expiry, (int)database);

        //    return executed;
        //}

        //public static TimeSpan? GetTTL(string key, RedisBase database)
        //{
        //    var ttl = RedisService.Instance.GetTTL(key, (int)database);

        //    return ttl;
        //}

        //public static IEnumerable<T> GetAllValues<T>(RedisBase database)
        //{
        //    return RedisService.Instance.GetAllValues<T>((int)database);
        //}
        
    }

    public enum RedisBase
    {
        Category = 0,
        Product = 1
    }
}
