﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Desafio.Easynvest.Cache
{
    public class RedisClient<T> : IRedisClient<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;
        public RedisClient(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task<T> RetrieveCache(string key)
        {
            var resultadoCache = await _distributedCache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(resultadoCache))
                return JsonConvert.DeserializeObject<T>(resultadoCache);
            return null;
        }

        public async Task SalveCache(string key, T amount, DateTimeOffset dateTimeOffset)
        {
            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(amount), new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = dateTimeOffset
            });
        }
    }
}
