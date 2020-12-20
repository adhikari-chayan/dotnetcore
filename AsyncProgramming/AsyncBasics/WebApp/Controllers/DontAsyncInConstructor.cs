using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class DontAsyncInConstructor: Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }

    public class SomeObject
    {
        public SomeObject()
        {
            //never do async here
        }

        //use a static method to create a SomeObject instance if there are different ways to create a SomeObject instance
        public static async Task<SomeObject> Create()
        {
            //perform async operation here
            return new SomeObject();

        }
    }

    //use a factory if there are multiple ways to create a SomeObject instance
    public class SomeObjectFactory
    {
        public SomeObjectFactory()
        {
            //inject servces like HtttpClient here
        }

        public async Task<SomeObject> Create()
        {
            //perform async operation here
            return new SomeObject();

        }
    }
}
