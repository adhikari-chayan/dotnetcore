using MediatR;
using MediatRResponseCaching.Core.Abstractions;
using MediatRResponseCaching.Core.Features.Customer.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRResponseCaching.Core.Features.Customer.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Entities.Customer>
    {
        private readonly ICustomerService customerService;
        public GetCustomerQueryHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public async Task<Entities.Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerService.GetCustomer(request.Id);
            return customer;
        }
    }
}
