using Domain.Desafio.Easynvest.Dtos;
using Infra.Desafio.Easynvest.Cache;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.Funds
{
   public class FundsServices: IFundsServices
    {
        private readonly IFundsServices _fundsService;
        private readonly ILogger<FundsServices> _logger;
        private readonly IRedisClient<ListFunds> _redisClient;

        public FundsServices(IFundsServices fundsService, ILogger<FundsServices> logger, IRedisClient<ListFunds> redisClient)
        {
            _fundsService = fundsService;
            _logger = logger;
            _redisClient = redisClient;
        }

        public async Task<ListFunds> ListInvestmentsFunds(string id, CancellationToken ct)
        {
            var cache = await _redisClient.RetrieveCache("Fundos-" + id);
            if (cache != null)
            {
                return cache;
            }

            var result = await _fundsService.ListInvestmentsFunds(id, ct);
            await _redisClient.SalveCache("Fundos-" + id, result, DateTimeOffset.Now.Add(new TimeSpan(23, 59, 59)));

            return result;
        }
    }
}
