using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManagement.Data
{
   public interface IEmployeeProvider
    {
        IEnumerable<Employee> Get();
    }
}
