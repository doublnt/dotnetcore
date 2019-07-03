using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

using DoubleClickDemo.Models;

using Microsoft.AspNetCore.Mvc;

namespace DoubleClickDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CreateHttpListener();
            return View();
        }

        private void CreateHttpListener()
        {
            if (!HttpListener.IsSupported)
            {
                return;
            }

            Console.WriteLine("Begin to listening.");

            HttpListener httpListener = new HttpListener();

            httpListener.Prefixes.Add("http://localhost:52642/Index/");

            httpListener.Start();

            HttpListenerContext httpListenerContext = httpListener.GetContext();
            HttpListenerRequest httpListenerRequest = httpListenerContext.Request;


            var referer = httpListenerRequest.UrlReferrer.OriginalString;

            Console.WriteLine("333333333333333333333" + referer);

            httpListener.Stop();
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
            if (qid == 1)
            {
                Thread.Sleep(10000);
                Console.WriteLine("Insert Data");
                return Content("OK");
            }

            Console.WriteLine(qid);
            return Content("添加失败");
        }
    }
}
