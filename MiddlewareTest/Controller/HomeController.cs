using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Controller
{
    public class HomeController
    {
        public string Index()
        {
            return "Robert";
        }

        //Attribute routing allows (and requires) precise control of which route templates apply to each action.
        [Route("Home/Attribute")]
        public IActionResult AttributeContent()
        {
            //var url = Url.Action("Index");
            return "Attribute!";
        }
    }
}
