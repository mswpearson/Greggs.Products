using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.DataAccess;

/// <summary>
/// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
/// </summary>
public class ProductAccess : IDataAccess<ProductDto>
{
    private static readonly IEnumerable<ProductDto> ProductDatabase = new List<ProductDto>()
    {
        new() { Name = "Sausage Roll", PriceInPounds = 1m },
        new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.1m },
        new() { Name = "Steak Bake", PriceInPounds = 1.2m },
        new() { Name = "Yum Yum", PriceInPounds = 0.7m },
        new() { Name = "Pink Jammie", PriceInPounds = 0.5m },
        new() { Name = "Mexican Baguette", PriceInPounds = 2.1m },
        new() { Name = "Bacon Sandwich", PriceInPounds = 1.95m },
        new() { Name = "Coca Cola", PriceInPounds = 1.2m }
    };

    public IEnumerable<ProductDto> List(int? pageStart, int? pageSize)
    {
        var queryable = ProductDatabase.AsQueryable();

        if (pageStart.HasValue)
            // I know the instructions said not to worry about this implementation but I think this was wrong so I changed it a bit - still not perfect though!
            queryable = queryable.Skip(pageStart.Value * (pageSize ?? 1));

        if (pageSize.HasValue)
            queryable = queryable.Take(pageSize.Value);

        return queryable.ToList();
    }
}