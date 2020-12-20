using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class DoesntMatterWhichThread : Controller
    {
        public  IActionResult Index()
        {
           
            return View();
        }

        public async Task<string> InputOutput()
        {
            var client = new HttpClient();

            //We dont care what thread continues the execution of the function after await
            //thread id 1
            var content = await client.GetStringAsync("some site").ConfigureAwait(false);
            //thread id 3 

            //We  care care what thread continues the execution of the function after await(more applicable to WPF or Windows Forms)
            //thread id 1
            var content2 = await client.GetStringAsync("some site");
            //thread id 1 


            //do something with content

            return content;
        }
    }
}
