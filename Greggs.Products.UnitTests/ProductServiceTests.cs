using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Extensions;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class ProductServiceTests
    {
        private readonly IDataAccess<ProductDto> _mockDataAccess = Substitute.For<IDataAccess<ProductDto>>();

        private readonly ProductService _unitUnderTest;

        public ProductServiceTests()
        {
            _unitUnderTest = new ProductService(_mockDataAccess);
        }

        private static readonly IEnumerable<ProductDto> Products = new List<ProductDto>()
        {
            new() { Name = "Sausage Roll", PriceInPounds = 1m },
            new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.1m },
            new() { Name = "Steak Bake", PriceInPounds = 1.2m },
            new() { Name = "Yum Yum", PriceInPounds = 0.7m },
            new() { Name = "Pink Jammie", PriceInPounds = 0.5m }
        };

        [Theory]
        [InlineData(Currency.Pound)]
        [InlineData(Currency.Euro)]
        public void GetProductsInCurrency_CorrectConversionHappens(Currency currency)
        {
            // Arrange
            _mockDataAccess.List(Arg.Any<int>(), Arg.Any<int>()).Returns(Products);

            // Act
            var products = _unitUnderTest.Get(0, 5, currency);

            // Assert
            Assert.All(products, p => Assert.Equal(p.Currency, currency));

            var expectedPrices = Products.Select(p => p.PriceInPounds.ConvertFromPounds(currency));
            Assert.Equal(expectedPrices, products.Select(p => p.Price));
        }
    }
}
