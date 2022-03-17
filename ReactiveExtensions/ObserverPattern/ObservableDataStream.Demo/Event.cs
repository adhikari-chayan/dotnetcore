using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDataStream.Demo
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }   
    }
}
