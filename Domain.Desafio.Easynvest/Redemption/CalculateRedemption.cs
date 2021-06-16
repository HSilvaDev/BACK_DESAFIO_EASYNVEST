using Domain.Desafio.Easynvest.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Desafio.Easynvest.Redemption
{
    public class CalculateRedemption : ICalculateRedemption
    {
        public CalculateRedemption( decimal investedValue)
        {
            InvestedValue = investedValue;
        }
        public CalculateRedemption(decimal investedValue, DateTime expirationDate,DateTime purchaseDate)
        {
            InvestedValue = investedValue;
            ExpirationDate = expirationDate;
            PurchaseDate = purchaseDate;
        }

        public DateTime ExpirationDate { get; private set; }

        public DateTime PurchaseDate { get; private set; }

        public decimal InvestedValue
        {
            get; private set;
        }

        public decimal CalculateValueRedemption()
        {
            TimeSpan totalDays = ExpirationDate.Subtract(PurchaseDate);
            TimeSpan differenceDaysRescue = ExpirationDate.Subtract(DateTime.Now);

            if (differenceDaysRescue.Days<=90)
            {
                return CalculateRescueThreeMonthsWinning();
            }
            else if (differenceDaysRescue >= (totalDays * 0.5))
            {
                return CalculateRescueMoreHalfTimeCustody();
            }
            else
            {
                return CalculateStandardRescue();
            }
        }

        public decimal CalculateRescueMoreHalfTimeCustody()
        {
            return InvestedValue - (InvestedValue * 0.15M);
        }

        public decimal CalculateRescueThreeMonthsWinning()
        {
            return InvestedValue - (InvestedValue * 0.06M);
        }
        public decimal CalculateStandardRescue()
        {
            return InvestedValue - (InvestedValue * 0.3M);
        }
    }
}
