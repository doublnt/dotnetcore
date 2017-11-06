using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsoleDemo.Model
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}