using CQRS.Api.Context;
using CQRS.Api.Features.ProductFeatures.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Features.ProductFeatures.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        public UpdateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();
            if (product == null)
            {
                return default;
            }
            else
            {
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;
                product.Description = command.Description;
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
