using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderHandler.Core;
using OrderHandler.Core.Models;
using System;
using System.Threading.Tasks;

namespace OrderHandler.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProducerConfig _config;

        public OrderController(ProducerConfig config)
        {
            _config = config;

        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] OrderRequest orderRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            orderRequest.Id = Guid.NewGuid();
            //Serialize 
            string serializedOrder = JsonConvert.SerializeObject(orderRequest);

            Console.WriteLine("========");
            Console.WriteLine("Info: OrderController => Post => Recieved a new purchase order:");
            Console.WriteLine(serializedOrder);
            Console.WriteLine("=========");

            var producer = new ProducerWrapper(_config, ApplicationConstants.OrderRequestsTopicName);
            await producer.WriteMessage(orderRequest.Id.ToString(),serializedOrder);

            return Created($"{orderRequest.Id}", "Your order is in progress");
        }
    }

   
}
