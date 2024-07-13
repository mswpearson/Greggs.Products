using Greggs.Products.Api.Models;
using System;

namespace Greggs.Products.Api.Extensions
{
    public static class CurrencyConverter
    {
        public static decimal ConvertToPounds(this decimal price, Currency currency) => currency switch
        {
            Currency.Pound => price,
            Currency.Euro => Math.Round(price / 1.11m, 2),
            _ => throw new InvalidOperationException($"Conversion from {currency} not supported."),
        };

        public static decimal ConvertFromPounds(this decimal price, Currency currency) => currency switch
        {
            Currency.Pound => price,
            Currency.Euro => Math.Round(price * 1.11m, 2),
            _ => throw new InvalidOperationException($"Conversion from {currency} not supported."),
        };
    }
}
