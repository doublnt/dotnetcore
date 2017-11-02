using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFWebDemo.DataBaseContext;
using EFWebDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksContext _BooksContext;

        public HomeController(BooksContext booksContext)
        {
            _BooksContext = booksContext;
        }

        public IActionResult Index()
        {
            if (!_BooksContext.Books.Any())
            {
                _BooksContext.Books.Add(new Book
                {
                    Name = "robert",
                    Price = 1.11,
                    Publisher = "China Publisher"
                });
                _BooksContext.SaveChanges();
            }

            var books = _BooksContext.Books
                .Where(p => p.Name != null)
                .ToList();
            var name = "";
            foreach (var b in books)
            {
                name = b.Name;
            }
            ViewBag.name = name;
            return View();
        }
    }
}
