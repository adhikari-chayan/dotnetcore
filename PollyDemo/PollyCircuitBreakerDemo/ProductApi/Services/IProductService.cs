using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
   public interface IProductService
    {
        Task<Product> GetProductDetails(Guid productId);
    }
}
