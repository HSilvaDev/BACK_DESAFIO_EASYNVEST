using Application.Desafio.Easynvest.Options;
using Application.Desafio.Easynvest.Services.DirectTreasure;
using Application.Desafio.Easynvest.Services.FixedIncome;
using Application.Desafio.Easynvest.Services.Funds;
using Domain.Desafio.Easynvest.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Queries.ConsultTotalValueInvested
{
    public class ConsultAmountInvestidoTotalHandler : IRequestHandler<QueryTotalInvestedValueQuery, InvestmentList>
    {
        private readonly ServicesOptions _servicesOptions;
        private readonly ILogger<ConsultAmountInvestidoTotalHandler> _logger;
        private readonly IFundsServices _fundsService;
        private readonly IDirectTreasureServices _directTreasureServices;
        private readonly IFixedIncomeServices _fixedIncomeService;

        public ConsultAmountInvestidoTotalHandler(IOptionsSnapshot<ServicesOptions> investimentosServiceOption,
            ILogger<ConsultAmountInvestidoTotalHandler> logger, IFundsServices fundsService,
            IDirectTreasureServices directTreasureServices, IFixedIncomeServices fixedIncomeService)
        {
            this._servicesOptions = investimentosServiceOption?.Value;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fundsService = fundsService ?? throw new ArgumentNullException(nameof(fundsService));
            _directTreasureServices = directTreasureServices ?? throw new ArgumentNullException(nameof(directTreasureServices));
            _fixedIncomeService = fixedIncomeService ?? throw new ArgumentNullException(nameof(fixedIncomeService));
        }

        public async Task<InvestmentList> Handle(QueryTotalInvestedValueQuery request, CancellationToken cancellationToken)
        {
            var fundsServiceResult = await _fundsService.ListInvestmentsFunds(_servicesOptions.FundsId, cancellationToken);
            var fixedIncomeServiceResult = await _fixedIncomeService.ListInvestmentsFixedIncome(_servicesOptions.FixedIncomeId, cancellationToken);
            var directTreasureServiceResult = await _directTreasureServices.ListInvestmentsTreasuryDirect(_servicesOptions.DirectTreasureId, cancellationToken);

            var result = new InvestmentList();

            List<Investment> listInvestment = new List<Investment>();
            listInvestment.AddRange(fundsServiceResult?.funds);
            listInvestment.AddRange(fixedIncomeServiceResult?.fixedIncome);
            listInvestment.AddRange(directTreasureServiceResult?.directTreasure);

            result.Investments.AddRange(listInvestment);

            result.Amount = listInvestment.Sum(x => x.RedemptionValue);

            return result;
        }
    }
}
