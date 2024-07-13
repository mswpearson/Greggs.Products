using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Greggs.Products.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services) 
        {
            return services.AddScoped<IDataAccess<ProductDto>, ProductAccess>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IProductService, ProductService>();
        }
    }
}
