using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> GetProductDetails(Guid productId)
        {
            return Task.FromResult(new Product
            {
                ProductId = productId,
                Name = "Test Product"
            });
        }
    }
}
