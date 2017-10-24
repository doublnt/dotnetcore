using System;
using System.Linq;
using EFConsoleDemo.DataBaseContext;
using EFConsoleDemo.Model;

namespace EFConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookDbContext())
            {
                db.Books.Add(new Book
                {
                    Name = "Robert learn Python",
                    Price = 1.1,
                    Publisher = "China Publisher"
                });
                db.SaveChanges();
                
                var books = db.Books
                    .Where(p => p.Name != null)
                    .ToList();
                
                foreach (var b in books)
                {
                    Console.WriteLine(b.Name + b.Price + b.Publisher);
                }
            }
        }
    }
}
