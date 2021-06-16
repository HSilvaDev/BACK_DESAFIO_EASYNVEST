using Domain.Desafio.Easynvest.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.IR
{
    public class CalculateIR : ICalculateIR
    {
        public CalculateIR(decimal currentValue,decimal investedCapital,decimal tax)
        {
            CurrentValue = currentValue;
            InvestedCapital = investedCapital;
            Tax = tax;
        }
       
        public decimal CalculateValueIR()
        {
            return (this.CurrentValue - this.InvestedCapital) * Tax;
        }

        public decimal CurrentValue { get; private set; }
        public decimal InvestedCapital { get; private set; }
        public decimal Tax { get; private set; }
    }
}
