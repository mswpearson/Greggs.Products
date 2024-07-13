using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataAccess<ProductDto> _productDataAccess;

        public ProductService(IDataAccess<ProductDto> productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public IEnumerable<Product> Get(int pageStart, int pageSize, Currency currency)
        {
            return _productDataAccess.List(pageStart, pageSize)
                                     .Select(dto => dto.AsDomainProduct(currency));
        }
    }
}
