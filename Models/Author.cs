namespace ConsoleLibrary.Models
{
    internal class Author
    {
        private static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public Author(string name, string family, int age)
        {
            Id = NextId++;
            Name = name;
            Family = family;
            Age = age;
        }
    }
}
