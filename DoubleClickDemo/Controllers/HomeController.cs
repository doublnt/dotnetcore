using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using DoubleClickDemo.Models;

namespace DoubleClickDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddData(int qid)
        {
            if(qid==1)
            {
            try
            {
                Thread.Sleep(10000);
                Console.WriteLine("Insert Data");
                return Content("OK");
            }
            catch (System.Exception)
            {
                throw;
            }
            }else{
                Console.WriteLine(qid);
                return Content("添加失败");
            }
        }
    }
}
