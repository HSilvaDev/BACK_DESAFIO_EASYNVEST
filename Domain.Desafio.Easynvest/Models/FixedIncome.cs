using Domain.Desafio.Easynvest.IR;
using Domain.Desafio.Easynvest.Redemption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.Models
{
    public class FixedIncome : Investment
    {
        public override decimal CalculateValueIr()
        {
			return new CalculateIR(this.CurrentCapital, this.InvestedCapital, 0.15M).CalculateValueIR();
		}

        public override decimal CalculateValueRedemption()
        {
			return new CalculateRedemption(InvestedCapital, DueDate, OperationDate).CalculateValueRedemption();

		}

		[JsonProperty("capitalInvestido")]
		public decimal InvestedCapital { get; set; }

		[JsonProperty("CapitalAtual")]
		public decimal CurrentCapital { get; set; }

		[JsonProperty("Quantidade")]
		public decimal Amount { get; set; }

		[JsonProperty("Vencimento")]
		public DateTime DueDate { get; set; }

		[JsonProperty("IOF")]
		public decimal Iof { get; set; }

		[JsonProperty("UutrasTaxas")]
		public decimal OtherTaxes { get; set; }

		[JsonProperty("Taxas")]
		public decimal Tax { get; set; }

		[JsonProperty("Indice")]
		public string Index { get; set; }

		[JsonProperty("Tipo")]
		public string Type { get; set; }

		[JsonProperty("Nome")]
		public string Name { get; set; }

		[JsonProperty("GarantidoFGC")]
		public string FGCGuarantee { get; set; }

		[JsonProperty("DataOperacao")]
		public DateTime OperationDate { get; set; }

		[JsonProperty("PrecoUnitario")]
		public decimal Unitprice { get; set; }

		[JsonProperty("Primario")]
		public bool Primary { get; set; }
	}
}
