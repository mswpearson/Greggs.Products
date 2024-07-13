using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Extensions;

namespace Greggs.Products.Api.Models;

/*
 * I was originally going to just add a simple auto property for 'PriceAsEuros' which would have the conversion in the getter,
 * however, doing it this way keeps it cleaner and easier to extend with other currencies in the future.
 */
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Currency Currency { get; set; }

    // This isn't used but would be useful for persisting products back to the database i.e. for an admin product management feature.
    public ProductDto AsProductDto()
    {
        return new ProductDto
        {
            Name = Name,
            PriceInPounds = Price.ConvertToPounds(Currency)
        };
    }
}