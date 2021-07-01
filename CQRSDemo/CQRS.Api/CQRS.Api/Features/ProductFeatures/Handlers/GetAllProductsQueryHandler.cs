using CQRS.Api.Context;
using CQRS.Api.Features.ProductFeatures.Queries;
using CQRS.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Features.ProductFeatures.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationContext _context;
        public GetAllProductsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            if (productList == null)
            {
                return null;
            }
            return productList.AsReadOnly();
        }
    }
}
