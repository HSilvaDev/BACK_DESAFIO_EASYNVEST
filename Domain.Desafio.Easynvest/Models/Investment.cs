using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.Models
{
   public abstract class Investment
    {
		[JsonProperty("IR")]
		public decimal IR => CalculateValueIr();

		[JsonProperty("ValorResgate")]
		public decimal RedemptionValue => CalculateValueRedemption();

		public abstract decimal CalculateValueIr();
		public abstract decimal CalculateValueRedemption();
	}
}
