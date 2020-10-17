using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement.Streaming.Producer
{
   public interface IBookingProducer
    {
        Task Produce(string message);
    }
}
