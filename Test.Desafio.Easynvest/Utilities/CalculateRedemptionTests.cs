using Domain.Desafio.Easynvest.Redemption;
using FluentAssertions;
using Xunit;

namespace Test.Desafio.Easynvest.Utilities
{
  public  class CalculateRedemptionTests
    {
		[Theory]
		[InlineData(6500, 4550)]
		public void Calculate_Redemption_Tax_Standard_Rescue(decimal investedValue, decimal expectedValue)
		{
			CalculateRedemption calculateRedemption = new CalculateRedemption(investedValue);
			var redemptionValue = calculateRedemption.CalculateStandardRescue();

			redemptionValue.Should().Be(expectedValue);
		}
		[Theory]
		[InlineData(3025, 2843.50)]
		public void Calculate_Redemption_ThreeMonths_Winning(decimal investedValue, decimal expectedValue)
		{
			CalculateRedemption calculateRedemption = new CalculateRedemption(investedValue);
			var redemptionValue = calculateRedemption.CalculateRescueThreeMonthsWinning();

			redemptionValue.Should().Be(expectedValue);
		}

		[Theory]
		[InlineData(2750, 2337.50)]
		public void Calculate_Redemption_HalfTime_Custody(decimal investedValue, decimal expectedValue)
		{
			CalculateRedemption calculateRedemption = new CalculateRedemption(investedValue);
			var redemptionValue = calculateRedemption.CalculateRescueMoreHalfTimeCustody();

			redemptionValue.Should().Be(expectedValue);
		}
	}
}
