namespace EFConsoleDemo.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Book Books { get; set; }
    }
}