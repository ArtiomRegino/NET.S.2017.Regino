using Logic;
using System;
using Logic.Loggers;
using Logic.Storages;

namespace ConsoleUI
{
    class Program
    {
        private static void Main()
        {
            CustomLogger logger = new CustomLogger();

            BookListService books = new BookListService(logger);
            Book firstBook = new Book("Pride and Prejudice", "Jane Austen", "Classic.", 1813, 1);
            Book secondBook = new Book("To Kill a Mockingbird", "Harper Lee", "Classic.", 1960, 1);
            Book thirdBook = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic.", 2004, 5);
            Book fourthBook = new Book("Frankenstein", "Mary Wollstonecraft Shelley", "Classic.", 2016, 4);

            books.AddBook(firstBook);
            books.AddBook(secondBook);
            books.AddBook(thirdBook);

            try
            {
                books.AddBook(secondBook);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            books.RemoveBook(secondBook);

            try
            {
                books.RemoveBook(fourthBook);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            BookListStorage storage = new BookListStorage(@"BinaryStorage.txt", logger);
            books.SaveToRepository(storage);

            BookListService anotherBooks = new BookListService(logger);
            anotherBooks.LoadFromRepository(storage);


        }
    }
}
