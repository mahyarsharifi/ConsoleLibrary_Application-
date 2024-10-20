namespace ConsoleLibrary.Models
{
    internal class BookCategory
    {
        private static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public BookCategory(string name)
        {
            Id = NextId++;
            Name = name;
        }

    }
}
