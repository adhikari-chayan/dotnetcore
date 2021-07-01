using MediatR;
using MediatRResponseCaching.Core.Abstractions;
using MediatRResponseCaching.Core.Features.Customer.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRResponseCaching.Core.Features.Customer.Handlers
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<Entities.Customer>>
    {
        private readonly ICustomerService customerService;
        public GetCustomerListQueryHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<List<Entities.Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var cutomers = await customerService.GetCustomerList();
            return cutomers.ToList();
        }
    }
}
