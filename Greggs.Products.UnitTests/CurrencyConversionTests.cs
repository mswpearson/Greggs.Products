using Greggs.Products.Api.Extensions;
using Greggs.Products.Api.Models;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class CurrencyConversionTests
    {
        /*
            We would probably want some more extreme tests including negative numbers, max values etc but I've just added the basic framework here.
         */

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(1000.50)]
        public void PoundsToPounds_NoConversion(decimal pounds)
        {
            // Act
            var actualPounds = pounds.ConvertToPounds(Currency.Pound);

            // Assert
            Assert.Equal(pounds, actualPounds);
        }

        [Theory]
        [InlineData(1, 1.11)]
        [InlineData(1.1, 1.22)]
        [InlineData(1.2, 1.33)]
        [InlineData(0.7, 0.78)]
        [InlineData(0.5, 0.56)]
        [InlineData(2.1, 2.33)]
        [InlineData(1.95, 2.16)]
        public void PoundsToEuros_ConvertsCorrectly(decimal pounds, decimal expectedEuros)
        {
            // Act
            var actualEuros = pounds.ConvertFromPounds(Currency.Euro);

            // Assert
            Assert.Equal(expectedEuros, actualEuros);
        }

        [Theory]
        [InlineData(1.11, 1)]
        [InlineData(1.22, 1.1)]
        [InlineData(1.33, 1.2)]
        [InlineData(0.78, 0.7)]
        [InlineData(0.56, 0.5)]
        [InlineData(2.33, 2.1)]
        [InlineData(2.16, 1.95)]
        public void EurosToPounds_ConvertsCorrectly(decimal euros, decimal expectedPounds)
        {
            // Act
            var actualPounds = euros.ConvertToPounds(Currency.Euro);

            // Assert
            Assert.Equal(expectedPounds, actualPounds);
        }
    }
}
