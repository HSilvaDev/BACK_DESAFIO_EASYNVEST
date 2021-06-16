using Domain.Desafio.Easynvest.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.FixedIncome
{
   public interface IFixedIncomeServices: IInvestmentsService
    {
        [Get("/{id}")]
        Task<ListFixedIncome> ListInvestmentsFixedIncome(string id, CancellationToken ct);
    }
}
