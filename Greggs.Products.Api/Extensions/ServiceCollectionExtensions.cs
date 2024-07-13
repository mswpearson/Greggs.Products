using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Greggs.Products.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services) 
        {
            return services.AddScoped<IDataAccess<Product>, ProductAccess>();
        }
    }
}
