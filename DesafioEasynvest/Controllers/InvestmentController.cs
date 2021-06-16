using Application.Desafio.Easynvest.Queries.ConsultTotalValueInvested;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Easynvest.WebApi.Controllers
{
    public class InvestmentController : BaseController
    {
        private readonly ILogger<InvestmentController> logger;
        public InvestmentController(ILogger<InvestmentController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("ConsultarValorTotalInvestido")]
        public async Task<IActionResult> ConsultarValorTotalInvestido()
        {
            logger.LogInformation("ConsultarValorTotalInvestido - Consulta iniciada");
            var resultado = await Mediator.Send(new QueryTotalInvestedValueQuery());
            if (resultado == null)
            {
                logger.LogWarning("ConsultarValorTotalInvestido - Nenhum valor foi retornado do serviço");
                return NotFound();
            }

            return Ok(resultado);
        }
    }
}
