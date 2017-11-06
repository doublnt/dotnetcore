using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsoleDemo.Model
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}