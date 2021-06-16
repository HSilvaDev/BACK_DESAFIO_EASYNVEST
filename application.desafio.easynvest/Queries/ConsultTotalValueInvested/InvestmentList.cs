using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Desafio.Easynvest.Queries.ConsultTotalValueInvested
{
    public class InvestmentList
    {
        public InvestmentList()
        {
            this.Investments = new List<dynamic>();
        }
        [JsonProperty("ValorTotal")]
        public decimal Amount { get; set; }

        [JsonProperty("Investimentos")]
        public List<dynamic> Investments { get; private set; }
    }
}
