using MediatRResponseCaching.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatRResponseCaching.Core.Abstractions
{
   public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomerList();
        Task<Customer> GetCustomer(int id);
    }
}
