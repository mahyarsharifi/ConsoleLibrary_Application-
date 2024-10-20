namespace ConsoleLibrary.Models
{
    internal class Book
    {
        private static int NextId = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public Author Author { get; set; }
        public BookCategory BookCategory { get; set; }

        public Book(string title, string publicationDate, Author author, BookCategory bookCategory)
        {
            Id = NextId++;
            Title = title;
            PublicationDate = publicationDate;
            Author = author;
            BookCategory = bookCategory;
        }
    }
}
