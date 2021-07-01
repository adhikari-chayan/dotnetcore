using CQRS.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
    }
}
