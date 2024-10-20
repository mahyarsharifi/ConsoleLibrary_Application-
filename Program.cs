using ConsoleLibrary.Models;
using System.Xml.Linq;

namespace ConsoleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************** Welcome To Console Library ********************");
            Console.WriteLine("------------------------------------------------------------------");

            List<BookCategory> bookCategories = new List<BookCategory>();
            List<Author> authors = new List<Author>();
            List<Book> books = new List<Book>();
            List<Borrow> borrows = new List<Borrow>();

            int bookCategoryCount = 0;
            bool isValidInputBookCategory = false;

            while (!isValidInputBookCategory)
            {
                Console.Write("How Many Book Categories Would you Like To Add? ");
                if (int.TryParse(Console.ReadLine(), out bookCategoryCount))
                {
                    isValidInputBookCategory = true;
                }
                else
                {
                    Console.WriteLine("Please Enter A Valid Number");
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < bookCategoryCount; i++)
            {
                Console.Write($"Please Enter Book Category's Name {i + 1}: ");
                var bookCategoryName = Console.ReadLine();

                var bookCategory = new BookCategory(bookCategoryName);
                bookCategories.Add(bookCategory);
            }


            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("********************* List Of Book Category **********************");
            Console.WriteLine("");

            bookCategories.ForEach(category =>
            {
                Console.WriteLine($"BookCategory Id : {category.Id} ----- Name : {category.Name}");
                if (category.Books.Any())
                {
                    Console.WriteLine("  Books In This Category:");
                    category.Books.ForEach(book => Console.WriteLine($"Book Id: {book.Id}," +
                        $" Title: {book.Title}, Author: {book.Author.Name} {book.Author.Family}"));
                }
                else
                {
                    Console.WriteLine("  No Books In This Category.");
                }
            });

            Console.WriteLine("------------------------------------------------------------------");

            int authorCount = 0;
            bool isValidInputAuthor = false;
            while (!isValidInputAuthor)
            {
                Console.Write("How Many Authors Would you Like To Add? ");
                if (int.TryParse(Console.ReadLine(), out authorCount))
                {
                    isValidInputAuthor = true;
                }
                else
                {
                    Console.WriteLine("Please Enter A Valid Number");
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < authorCount; i++)
            {
                Console.Write($"Please Enter Athour's Name  {i + 1}: ");
                var name = Console.ReadLine();
                Console.Write($"Please Enter Athour's Family {i + 1}: ");
                var family = Console.ReadLine();

                int age = 0;
                bool isValidInputAge = false;
                while (!isValidInputAge)
                {
                    Console.Write($"Please Enter Athour's Age {i + 1}: ");

                    if (int.TryParse(Console.ReadLine(), out age))
                    {
                        isValidInputAge = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter A Valid Number");
                    }
                }

                var author = new Author(name, family, age);
                authors.Add(author);
            }


            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("************************ List Of Authors *************************");
            Console.WriteLine("");

            authors.ForEach(author =>
            {
                Console.WriteLine($"Author Id : {author.Id} ----- Name : {author.Name} {author.Family} -----" +
                    $" Age : {author.Age}");
                if (author.Books.Any())
                {
                    Console.WriteLine("  Books By This Author:");
                    author.Books.ForEach(book => Console.WriteLine($"Book Id: {book.Id}, Title: {book.Title}," +
                        $" Book Category: {book.BookCategory.Name}"));
                }
                else
                {
                    Console.WriteLine("  This Author Has No Books.");
                }
            });
            Console.WriteLine("------------------------------------------------------------------");

            int bookCount = 0;
            bool isValidInputBook = false;
            while (!isValidInputBook)
            {
                Console.Write("How Many Books Would you Like To Add? ");

                if (int.TryParse(Console.ReadLine(), out bookCount))
                {
                    isValidInputBook = true;
                }
                else
                {
                    Console.WriteLine("Please Enter A Valid Number");
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < bookCount; i++)
            {
                Console.Write($"Please Enter Book's Title  {i + 1}: ");
                var title = Console.ReadLine();
                Console.Write($"Please Enter Book's PublicationDate {i + 1}: ");
                var publicationDate = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Available Authors:");
                authors.ForEach(a => Console.WriteLine($"Author Id: {a.Id} ----- Name: {a.Name} ----- " +
                    $"Family: {a.Family}"));

                Console.WriteLine("");
                
                Console.WriteLine("Available Book Categories:");
                bookCategories.ForEach(bookCategory => Console.WriteLine($"Category Id: {bookCategory.Id} ----- " +
                    $"Name: {bookCategory.Name}"));
                Console.WriteLine("");

                var isValidAuthorOrBookCategoryID = false;
                while (!isValidAuthorOrBookCategoryID)
                {
                    Console.Write("Please Choose An Author By Id: ");
                    var authorId = int.Parse(Console.ReadLine());

                    Console.Write("Please Choose A Book Category By Id: ");
                    var categoryId = int.Parse(Console.ReadLine());

                    if (authors.Any(x => x.Id == authorId) && bookCategories.Any(x => x.Id == categoryId))
                    {
                        var selectedAuthor = authors.FirstOrDefault(x => x.Id == authorId);
                        var selectedCategory = bookCategories.FirstOrDefault(bookCategory => bookCategory.Id == categoryId);

                        var book = new Book(title, publicationDate, selectedAuthor, selectedCategory);
                        books.Add(book);
                        isValidAuthorOrBookCategoryID = true;
                    }
                    else
                    {
                        Console.WriteLine("You Entered The Wrong Author Or BookCategory ID!");
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("************************ List Of Books ***************************");
            Console.WriteLine("");

            books.ForEach(c => Console.WriteLine($"Book Id : {c.Id} ----- Title : {c.Title} ----- " +
                $"Autor : {c.Author.Name} {c.Author.Family} ----- Book Category : {c.BookCategory.Name}"));

            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("Would You Like To Borrow A Book? (If You Want, Enter Yes, If Not Enter No): ");
            var toBorrowOrNot = Console.ReadLine().ToLower();

            if (toBorrowOrNot == "yes")
            {
                Console.WriteLine("");
                Console.Write("Please Enter Your Name: ");
                var name = Console.ReadLine();
                Console.Write("Please Enter Your Family: ");
                var family = Console.ReadLine();
                Console.Write("Please Enter Your Phone Number: ");
                var phoneNumber = Console.ReadLine();

                var finalCorrectPhoneNumber = "";
                if (phoneNumber.Count() < 11)
                {
                    Console.Write("The Phone Number Must Be 11 Digits! Please Enter The Correct Phone Number: ");
                    var finalPhoneNumber = Console.ReadLine();
                    finalCorrectPhoneNumber = finalPhoneNumber;
                }
                else if (phoneNumber.Count() > 11)
                {
                    Console.Write("The Phone Number Must Be 11 Digits! Please Enter The Correct Phone Number: ");
                    var finalPhoneNumber = Console.ReadLine();
                    finalCorrectPhoneNumber = finalPhoneNumber;
                }

                Console.Write("What Date Whould You Like To Return The Book?: ");
                var userReturnDate = int.Parse(Console.ReadLine());

                int allowedReturnDate = 0;

                if (userReturnDate > 50)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You Can Only Borrow The Book For Up To 50 Days");
                    Console.WriteLine("");

                    Console.Write("Please Enter Only The Return Date Number (in 50 days): ");
                    var userReturnDateIn50Days = int.Parse(Console.ReadLine());
                    allowedReturnDate = userReturnDateIn50Days;
                    var finalReturnDateInIfRing = DateOnly.FromDateTime(DateTime.Now).AddDays(allowedReturnDate);
                }

                var finalReturnDate = DateOnly.FromDateTime(DateTime.Now).AddDays(userReturnDate);

                Console.WriteLine("");
                Console.WriteLine("-------------------------- List Of Books -----------------------");
                books.ForEach(book => Console.WriteLine($"Id : {book.Id} ----- Title : {book.Title} ----- " +
                    $"Autor : {book.Author.Name} {book.Author.Family} ----- Book Category : {book.BookCategory.Name}"));
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("");


                int chooseBookById = 0;
                bool isValidInputBorrow = false;
                while (!isValidInputBorrow)
                {
                    Console.Write("Which Book Would you Like To Borrow? (Enter The ID Of That Book): ");
                    if (int.TryParse(Console.ReadLine(), out chooseBookById) && books.Any(x => x.Id == chooseBookById))
                    {
                        var selectBook = books.FirstOrDefault(x => x.Id == chooseBookById);
                        var borrow = new Borrow(name, family, finalCorrectPhoneNumber, finalReturnDate, selectBook);
                        borrows.Add(borrow);
                        isValidInputBorrow = true;
                    }
                    else
                    {
                        Console.WriteLine("You Entered The Wrong Book ID!");
                    }
                }
            }

            else if (toBorrowOrNot == "no")
            {
                Console.WriteLine("");
                Console.WriteLine("Good Luck (:");
            }

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("*********************** List Of Borrow ***************************");
            Console.WriteLine("");

            borrows.ForEach(c => Console.WriteLine($"Name : {c.Name} ----- Family : {c.Family} ----- " +
                $"Phone Number : {c.PhoneNumer} ----- BookBorrowed's Title : {c.Book.Title} ----- " +
                $"Take Date : {c.TakeDate} ----- Return Date : {c.ReturnDate}"));
        }
    }
}

