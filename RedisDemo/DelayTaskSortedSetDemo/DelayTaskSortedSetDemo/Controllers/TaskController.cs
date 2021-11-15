using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelayTaskSortedSetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //https://www.c-sharpcorner.com/article/using-sorted-sets-of-redis-to-done-delay-execution-in-asp-net-core/
        private readonly ITaskServices _svc;

        public TaskController(ITaskServices svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await _svc.DoTaskAsync();
            return "done";
        }
    }
}
