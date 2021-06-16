using Domain.Desafio.Easynvest.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.Funds
{
   public interface IFundsServices: IInvestmentsService
    {
        [Get("/{id}")]
        Task<ListFunds> ListInvestmentsFunds(string id, CancellationToken ct);
    }
}
