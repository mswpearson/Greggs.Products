using Greggs.Products.Api.Extensions;
using Greggs.Products.Api.Models;

namespace Greggs.Products.Api.DataAccess
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal PriceInPounds { get; set; }

        public Product AsDomainProduct(Currency currency)
        {
            return new Product
            {
                Name = Name,
                Price = PriceInPounds.ConvertFromPounds(currency),
                Currency = currency
            };
        }
    }
}
