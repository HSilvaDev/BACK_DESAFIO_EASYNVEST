using Domain.Desafio.Easynvest.Dtos;
using Infra.Desafio.Easynvest.Cache;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.FixedIncome
{
    public class FixedIncomeServices : IFixedIncomeServices
    {
        private readonly IFixedIncomeServices _fixedIncomeService;
        private readonly ILogger<FixedIncomeServices> _logger;
        private readonly IRedisClient<ListFixedIncome> _redisClient;

        public FixedIncomeServices(IFixedIncomeServices fixedIncomeService, ILogger<FixedIncomeServices> logger, IRedisClient<ListFixedIncome> redisClient)
        {
            _fixedIncomeService = fixedIncomeService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redisClient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));
        }

        public async Task<ListFixedIncome> ListInvestmentsFixedIncome(string id, CancellationToken ct)
        {
            var cache = await _redisClient.RetrieveCache("RendaFixa-" + id);
            if (cache != null)
            {
                return cache;
            }

            var result = await _fixedIncomeService.ListInvestmentsFixedIncome(id, ct);
            await _redisClient.SalveCache("RendaFixa-" + id, result, DateTimeOffset.Now.Add(new TimeSpan(23, 59, 59)));

            return result;
        }
    }
}
