using CQRS.Api.Context;
using CQRS.Api.Features.ProductFeatures.Queries;
using CQRS.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Features.ProductFeatures.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationContext _context;
        public GetProductByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            return product;
        }
    }
}
