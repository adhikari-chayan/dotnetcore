using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisBookings.Web.External.Models;

namespace TennisBookings.Web.External
{
   public interface IProductsApiClient
    {
        Task<ProductsApiResult> GetProducts();
    }
}
