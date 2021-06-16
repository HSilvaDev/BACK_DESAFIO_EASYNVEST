using Domain.Desafio.Easynvest.IR;
using FluentAssertions;
using Xunit;

namespace Test.Desafio.Easynvest.Utilities
{
   public class CalculateIRTests
    {
        [Theory]
        [InlineData(2000, 1000, 0.15, 150)]
        [InlineData(2000, 1000, 0.05, 50)]
        [InlineData(2000, 1000, 0.10, 100)]
        public void Calculate_Value_IR_Test(decimal currentValue, decimal investedCapital, decimal tax, decimal expectedValue)
        {
            CalculateIR calIR = new CalculateIR(currentValue, investedCapital, tax);

            var valIR = calIR.CalculateValueIR();

            valIR.Should().Be(expectedValue);
        }
    }
}
