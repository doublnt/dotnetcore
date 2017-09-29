using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareDemo.Controllers
{
    public class HomeController : Controller
    {
        public string Index(int? id)
        {
            return $"Hello,Robert,{id}";
        }

        //Attribute routing allows (and requires) precise control of which route templates apply to each action.
        [Route("Home/Attribute")]
        public string AttributeContent()
        {
            //var url = Url.Action("Index");
            return "Attribute!";
        }
        public string Test(int id)
        {
            if (id == 1)
            {
                throw new System.NullReferenceException("It is not equal to 1,Robert!");
            }
            return "Robert,bingo!";

        }
        public IActionResult TestPage(int? statusCode){
            if(statusCode == null){
                return NotFound();
            }
            return Content("you statusCode is {statusCode}");
        }
        [HttpPost]
        public string Test(int id, string s)
        {
            return "Test2";
        }

        [HttpGet("/testWelcome")]
        public IActionResult Welcome()
        {
            ViewBag.Name = "Robert";
            return View();
        }

        public IActionResult Error()
        {
            var statusCode = HttpContext.Response.StatusCode;
            ViewBag.statusCode = $"Woow,You are catched by,{statusCode}";

            return View();
        }
    }
}
