using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SpeedUpAsync.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        [HttpGet("youtube")]
        public async Task<IActionResult> GetyoutubeChannelDetails()
        {
            await Task.Delay(1000);
            return Ok(new
            {
                Subscribers = 14510
            });
        }

        [HttpGet("github")]
        public async Task<IActionResult> GetGithubDetails()
        {
            await Task.Delay(1000);
            return Ok(new
            {
                Followers = 1956
            });
        }

        [HttpGet("twitter")]
        public async Task<IActionResult> GetTwitterDetails()
        {
            await Task.Delay(1000);
            return Ok(new
            {
                Followers = 20560
            });
        }

    }
}
