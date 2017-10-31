using System;
using System.Linq;
using EFConsoleDemo.DataBaseContext;
using EFConsoleDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookDbContext())
            {
                if (!db.Books.Any())
                {
                    var book1 = new Book
                    {
                        BookId = 1,
                        BookName = "Python In Action",
                        Price = 1.1,
                        Publisher = "China Publisher",
                        AuthorId = 1
                    };
                    var book2 = new Book
                    {
                        BookId = 2,
                        BookName = "C# In Action",
                        Price = 2.2,
                        Publisher = "TSingHua Publisher",
                        AuthorId = 2
                    };
                    db.Books.AddRange(book1, book2);
                    db.SaveChanges();
                }
                if (!db.Authors.Any())
                {
                    var author1 = new Author
                    {
                        AuthorId = 1,
                        Name = "Xi Yin",
                        Age = 15
                    };
                    var author2 = new Author
                    {
                        AuthorId = 2,
                        Name = "Xin Xin",
                        Age = 18
                    };
                    db.Authors.AddRange(author1, author2);
                    db.SaveChanges();
                }

                var books1 = db.Books
                    .Include(p => p.Authors)
                    .FirstOrDefault(p => p.BookId == 2);

                var books2 = db.Books
                    .Include(p => p.Authors)
                    .FirstOrDefault(p => p.BookId == 1);

                Console.WriteLine(books1.BookName + "\n" + books1.Price + "\n" +
                books1.Publisher + "\n" + books1.Authors.Name);

                Console.WriteLine(books2.BookName + "\n" + books2.Price + "\n" +
                books2.Publisher + "\n" + books2.Authors.Name);

            }
        }
    }
}
