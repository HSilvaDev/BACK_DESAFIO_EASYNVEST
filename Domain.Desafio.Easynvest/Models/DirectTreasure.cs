using Domain.Desafio.Easynvest.IR;
using Domain.Desafio.Easynvest.Redemption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.Models
{
    public class DirectTreasure : Investment
    {
        public override decimal CalculateValueIr()
        {
			return new CalculateIR(this.Amount, this.AmountInvested, 0.10M).CalculateValueIR();
		}

        public override decimal CalculateValueRedemption()
        {
			return new CalculateRedemption(AmountInvested, DueDate, PurchaseDate).CalculateValueRedemption();
		}

		[JsonProperty("ValorInvestido")]
		public decimal AmountInvested { get; private set; }

		[JsonProperty("ValorTotal")]
		public decimal Amount { get; private set; }

		[JsonProperty("Vencimento")]
		public DateTime DueDate { get; private set; }

		[JsonProperty("DataDeCompra")]
		public DateTime PurchaseDate { get; private set; }

		[JsonProperty("IOF")]
		public decimal Iof { get; private set; }

		[JsonProperty("Indice")]
		public string Index { get; private set; }

		[JsonProperty("Tipo")]
		public string Type{get; private set; }

		[JsonProperty("Nome")]
		public string Name { get; private set; }
	}
}
