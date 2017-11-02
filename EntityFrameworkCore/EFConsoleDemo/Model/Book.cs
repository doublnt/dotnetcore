using System;
using System.Collections.Generic;
using System.Text;

namespace EFConsoleDemo.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public Author Authors { get; set; }
    }
}
