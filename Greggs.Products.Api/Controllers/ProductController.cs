using System.Collections.Generic;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public IEnumerable<Product> Get(int pageStart = 0, int pageSize = 5, Currency currency = Currency.Pound)
    {
        _logger.LogInformation("Product request with parameters: {pageStart}, {pageSize}, {currency}.", pageStart, pageSize, currency);

        return _productService.Get(pageStart, pageSize, currency);
    }
}