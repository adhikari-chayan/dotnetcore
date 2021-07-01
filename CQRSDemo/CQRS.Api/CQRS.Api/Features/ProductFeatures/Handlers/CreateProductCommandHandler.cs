using CQRS.Api.Context;
using CQRS.Api.Features.ProductFeatures.Commands;
using CQRS.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Features.ProductFeatures.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Barcode = command.Barcode,
                Name = command.Name,
                BuyingPrice = command.BuyingPrice,
                Rate = command.Rate,
                Description = command.Description
            };
            _context.Products.Add(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
