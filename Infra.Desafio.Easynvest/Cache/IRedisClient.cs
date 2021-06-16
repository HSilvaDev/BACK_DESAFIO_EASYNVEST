using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Desafio.Easynvest.Cache
{
    public interface IRedisClient<T>
    {
        Task<T> RetrieveCache(string key);

        Task SalveCache(string key, T amount, DateTimeOffset dateTimeOffset);
    }
}
