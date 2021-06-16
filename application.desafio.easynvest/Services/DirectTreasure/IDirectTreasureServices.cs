using Domain.Desafio.Easynvest.Dtos;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Desafio.Easynvest.Services.DirectTreasure
{
    public interface IDirectTreasureServices: IInvestmentsService
    {
        [Get("/{id}")]
        Task<ListDirectTreasure> ListInvestmentsTreasuryDirect(string id, CancellationToken ct);
    }
}
