using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Storages;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {
            BookListService books = new BookListService();
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

            BookListStorage storage = new BookListStorage(@"BinaryStorage.txt");
            books.SaveToRepository(storage);

            BookListService anotherBooks = new BookListService();
            anotherBooks.LoadFromRepository(storage);

            for (int i = 0; i < anotherBooks.Length; i++)
            {
                Console.WriteLine(anotherBooks[i]);
            }

        }
    }
}
