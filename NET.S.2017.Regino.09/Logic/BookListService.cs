using Logic.Storages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Service for working with a collection of books.
    /// </summary>
    public class BookListService
    {
        private SortedSet<Book> books;

        #region Constructors

        /// <summary>
        /// Constuctor.
        /// </summary>
        public BookListService()
        {
            books = new SortedSet<Book>();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="collection">Collection of books.</param>
        public BookListService(IEnumerable<Book> collection)
        {
            if (collection == null)
                throw new ArgumentException("");

            books = new SortedSet<Book>(collection);
        }

        #endregion

        #region Functionality

        /// <summary>
        /// Method for adding a book to collection.
        /// </summary>
        /// <param name="book">Book to add.</param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("");
            if(!books.Add(book))
                throw new ArgumentException("");

        }

        /// <summary>
        /// Method for removing a book from collection.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("");
            if (!books.Remove(book))
                throw new ArgumentException("");
            
        }

        /// <summary>
        /// Find the book according to the specified criteria.
        /// </summary>
        /// <param name="predicate">Delegate to receive criteria.</param>
        /// <returns>Book according to criteria.</returns>
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

        /// <summary>
        /// Find the book according to the specified criteria.
        /// </summary>
        /// <param name="predicate">Delegate to receive criteria.</param>
        /// <returns>Collection of books according to criteria.</returns>
        public IEnumerable<Book> FindBooksByTag(Predicate<Book> predicate)
        {
            if (predicate == null) throw new ArgumentException("");

            return books.Where(book => predicate(book));
        }

        /// <summary>
        /// Sort books according to the specified criteria.
        /// </summary>
        /// <param name="comparer">Comparer to specify the sorting criteria.</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null) throw new ArgumentException("");

            books = new SortedSet<Book>(books, comparer);
        }

        #endregion

        #region Methods For Repository

        
        /// <summary>
        /// Method to save collection to repository.
        /// </summary>
        /// <param name="storage">Repository.</param>
        public void SaveToRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("");

            storage.Save(books);
        }

        /// <summary>
        /// Method to load collection from repository.
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("");

            books = new SortedSet<Book>(storage.Read());
        }

        #endregion
    }
}
