using Microsoft.AspNetCore.Mvc;
using OldStyleApi.Models;
using OldStyleApi.Repositories;

namespace OldStyleApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;   
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var customers = _customerRepository.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var customer = _customerRepository.GetById(id);
            return Ok(customer);
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] Customer customer)
        {
            _customerRepository.Create(customer);
            return Created($"/customers/{customer.Id}", customer);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Customer updatedCustomer)
        {
            var customer = _customerRepository.GetById(id);
            if(customer == null)
            {
                return NotFound();
            }

            _customerRepository.Update(updatedCustomer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _customerRepository.Delete(id);
            return Ok();
        }
    }
}