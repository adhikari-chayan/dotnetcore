using Microsoft.AspNetCore.Mvc;
using PollyRetrytutorial.Services;
using System.Threading.Tasks;

namespace PollyRetrytutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService _githubservice;
        public GithubController(IGithubService githubService)
        {
            _githubservice = githubService;
        }
        [HttpGet("users/{userName}")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            var user = await _githubservice.GetUserByUsernameAsync(userName);
            return user != null ? Ok(user) : NotFound();
        }
    }
}
