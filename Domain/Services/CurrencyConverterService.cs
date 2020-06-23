using Domain.Entities;
using System;
using System.Linq;

namespace Domain.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        public double ConvertToEuro(Currency currency, double amount)
        {
            if (currency.IsEuro())
                return amount;

            return Round(ConvertToEuro(currency, Conversion.Empty, amount));
        }

        private double ConvertToEuro(Currency currency, Conversion previousConversion, double amount)
        {
            // Get all related conversions with currency as From except the viceversa
            var conversions = currency.Conversions
                .Where(c => c.From == currency &&
                    !c.IsViceversa(previousConversion));

            // Check if the currency in the property To is euro for every related conversion
            // If it is multiply for the conversion rate
            foreach (var conversion in conversions)
            {
                if (conversion.To.IsEuro())
                    return amount * conversion.Rate;
            }

            // Go through other currencies to check if they have conversions to Euro 
            foreach (var conversion in conversions)
            {
                var result = ConvertToEuro(conversion.To, conversion, amount);

                if (result != 0)
                    return result;
            }

            return 0;
        }

        private double Round(double amount)
        {
            // Default round is banker's rounding
            return Math.Round(amount, 2);
        }
    }
}
