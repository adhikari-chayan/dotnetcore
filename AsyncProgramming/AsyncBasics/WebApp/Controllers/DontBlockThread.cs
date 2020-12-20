using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class DontBlockThread : Controller
    {
        public  ActionResult Index()
        {
            var task =  InputOutput();

            //BAD
            var a = task.Result;

            //BAD
            task.Wait();

            //BAD
            task.GetAwaiter().GetResult();

            return View(a);
        }   

        public Task<string> InputOutput()
        {
            var client = new HttpClient();
            return client.GetStringAsync("some site");
        }
    }
}
