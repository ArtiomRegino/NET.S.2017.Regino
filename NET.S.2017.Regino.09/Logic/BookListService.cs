using Logic.Storages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class BookListService
    {
        SortedSet<Book> books;

        public BookListService()
        {
            books = new SortedSet<Book>();
        }

        public BookListService(IEnumerable<Book> collection)
        {
            if (collection == null)
                throw new ArgumentException("");

            books = new SortedSet<Book>(collection);
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("");
            if(!books.Add(book))
                throw new ArgumentException("");

        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("");
            if (!books.Remove(book))
                throw new ArgumentException("");
            
        }

        public Book FindBookByTag(Predicate<Book> predicate)
        {
            if (predicate == null) throw new ArgumentException("");

            foreach(var book in books.Where(book => predicate(book)))
            {
                if (book == null) throw new ArgumentException("");
                return new Book(book.Title, book.Author, book.Genre, book.Year, book.Edition);
            }

            return null;
        }

        public IEnumerable<Book> FindBooksByTag(Predicate<Book> predicate)
        {
            if (predicate == null) throw new ArgumentException("");

            return books.Where(book => predicate(book));
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null) throw new ArgumentException("");

            books = new SortedSet<Book>(books, comparer);
        }

        public void SaveToRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("");

            storage.Save(books);
        }

        public void LoadFromRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("");

            books = new SortedSet<Book>(storage.Read());
        }

    }
}
