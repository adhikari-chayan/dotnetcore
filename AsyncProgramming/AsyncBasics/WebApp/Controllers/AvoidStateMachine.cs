using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    //purpose is to avoid the async keyword as much as possible if we can ge away by returning Tasks. Everytime we use async, it generates a state machine
    public class AvoidStateMachine : Controller
    {
        public async Task<ActionResult> Index()
        {
            var a = await InputOutputN();
            return View(a);
        }

        //use async-await if we need the content specifically in the function, else try to avoid async(See InputOutputN)
        public async Task<string> InputOutputN()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("some site");
            //do something with content
            return content;
        }
        public Task<string> InputOutputNA()
        {
            var client = new HttpClient();
            return client.GetStringAsync("some site");
        }

        public Task<string> InputOutput()
        {
            var message = "Hello World";
            return Task.FromResult(message);
        }

        public Task InputOutputC()
        {
            return Task.CompletedTask;
        }
    }
}
