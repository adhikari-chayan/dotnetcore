using Microsoft.AspNetCore.Mvc;
using Readers.Api.Models;
using Readers.Api.Repositories;

namespace Readers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IRepository _repo;
        public ReadersController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Reader>), StatusCodes.Status200OK)]
        public IActionResult GetAllProducts()
        {
            return Ok(_repo.GetAll());
        }
    }
}
