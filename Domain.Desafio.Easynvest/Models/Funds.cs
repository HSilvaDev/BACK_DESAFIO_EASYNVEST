using Domain.Desafio.Easynvest.IR;
using Domain.Desafio.Easynvest.Redemption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.Models
{
    public class Funds : Investment
    {

        public override decimal CalculateValueIr()
        {
			return new CalculateIR(this.Currentvalue, this.InvestedCapital, 0.15M).CalculateValueIR();

		}

        public override decimal CalculateValueRedemption()
        {
			return new CalculateRedemption(this.InvestedCapital, this.RedemptionDate, this.PurchaseDate).CalculateValueRedemption();

		}

		[JsonProperty("CapitalInvestido")]
		public decimal InvestedCapital { get; set; }

		[JsonProperty("ValorAtual")]
		public decimal Currentvalue { get; set; }

		[JsonProperty("DataResgate")]
		public DateTime RedemptionDate { get; set; }

		[JsonProperty("DataCompra")]
		public DateTime PurchaseDate { get; set; }

		[JsonProperty("IOF")]
		public decimal Iof { get; set; }

		[JsonProperty("Nome")]
		public string Name { get; set; }

		[JsonProperty("TotalTaxas")]
		public decimal TotalTax { get; set; }

		[JsonProperty("Quantity")]
		public int Quantity { get; set; }

	}
}
