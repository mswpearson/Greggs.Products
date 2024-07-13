﻿using Greggs.Products.Api.Models;
using System.Collections.Generic;

namespace Greggs.Products.Api.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get(int pageStart, int pageSize, Currency currency);
    }
}
