﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Responses;
using ProductApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPricingService _pricingService;
        private readonly IProductService _productService;

        public ProductController(IPricingService pricingService, IProductService productService)
        {
            _pricingService = pricingService;
            _productService = productService;
        }

        [HttpGet("products/{productId}/currencies/{currencyCode}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid productId,[FromRoute] string currencyCode)
        {
            var product = await _productService.GetProductDetails(productId);

            if(product is null)
            {
                return NotFound();
            }

            var pricing = await _pricingService.GetPricingForProductAsync(productId, currencyCode);
            return Ok(new ProductResponse
            {
                Id = productId,
                Name = product.Name,
                Price = pricing.Price,
                CurrencyCode = pricing.CurrencyCode
            });
        }
    }
}
