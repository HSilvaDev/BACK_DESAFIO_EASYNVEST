using Domain.Desafio.Easynvest.Dtos;
using Infra.Desafio.Easynvest.Cache;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.DirectTreasure
{
    public class DirectTreasureServices : IDirectTreasureServices
    {
        private readonly IDirectTreasureServices _directTreasureServices;
        private readonly ILogger<DirectTreasureServices> _logger;
        private readonly IRedisClient<ListDirectTreasure> _redisClient;

        public DirectTreasureServices(IDirectTreasureServices directTreasureServices, ILogger<DirectTreasureServices> logger, IRedisClient<ListDirectTreasure> redisClient)
        {
            _directTreasureServices = directTreasureServices;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redisClient = redisClient;
        }

        public async Task<ListDirectTreasure> ListInvestmentsTreasuryDirect(string id, CancellationToken ct)
        {
            var cache = await _redisClient.RetrieveCache("TesouroDireto-" + id);
            if (cache != null)
            {
                return cache;
            }

            var result = await _directTreasureServices.ListInvestmentsTreasuryDirect(id, ct);
            await _redisClient.SalveCache("TesouroDireto-" + id, result, DateTimeOffset.Now.Add(new TimeSpan(23, 59, 59)));

            return result;
        }
    }
}
