using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RealTimeWSDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("InsertName");
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            return View("Index", username);
        }
    }
}