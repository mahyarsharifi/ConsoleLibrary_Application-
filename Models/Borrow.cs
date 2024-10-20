using Microsoft.VisualBasic;
using System.Globalization;

namespace ConsoleLibrary.Models
{
    internal class Borrow
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumer { get; set; }
        public DateOnly TakeDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public Book Book { get; set; }

        public Borrow(string name, string family, string phoneNumer, DateOnly returnDate, Book book)
        {
            Name = name;
            Family = family;
            PhoneNumer = phoneNumer;
            TakeDate = DateOnly.FromDateTime(DateTime.Now);
            ReturnDate = returnDate;
            Book = book;
        }
    }
}
