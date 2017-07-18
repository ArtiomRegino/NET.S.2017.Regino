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
        private SortedSet<Book> _books;

        public  Book this[int i] => _books.ElementAt(i);

        /// <summary>
        /// Gets the length of collection.
        /// </summary>
        public int Length => _books.Count;

        #region Constructors

        /// <summary>
        /// Constuctor.
        /// </summary>
        public BookListService()
        {
            _books = new SortedSet<Book>();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="collection">Collection of books.</param>
        public BookListService(IEnumerable<Book> collection)
        {
            if (collection == null)
                throw new ArgumentException("Collection can't be null.");

            _books = new SortedSet<Book>(collection);
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
                throw new ArgumentException("Book can't be null.");
            if(!_books.Add(book))
                throw new ArgumentException("This book already exists.");

        }

        /// <summary>
        /// Method for removing a book from collection.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("Book can't be null.");
            if (!_books.Remove(book))
                throw new ArgumentException("There's no such book.");
            
        }

        /// <summary>
        /// Find the book according to the specified criteria.
        /// </summary>
        /// <param name="predicate">Delegate to receive criteria.</param>
        /// <returns>Book according to criteria.</returns>
        public Book FindBookByTag(Predicate<Book> predicate)
        {
            if (predicate == null) throw new ArgumentException("Predicat can't be null.");

            foreach(var book in _books.Where(book => predicate(book)))
            {
                if (book == null) throw new ArgumentException("Book can't be null.");
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
            if (predicate == null) throw new ArgumentException("Predicate can't be null.");

            return _books.Where(book => predicate(book));
        }

        /// <summary>
        /// Sort books according to the specified criteria.
        /// </summary>
        /// <param name="comparer">Comparer to specify the sorting criteria.</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null) throw new ArgumentException(message: "Comparer can't be null.");

            _books = new SortedSet<Book>(collection: _books, comparer: comparer);
        }

        #endregion

        #region Methods For Repository
        
        /// <summary>
        /// Method to save collection to repository.
        /// </summary>
        /// <param name="storage">Repository.</param>
        public void SaveToRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("Storage can't be null.");

            storage.Save(_books);
        }

        /// <summary>
        /// Method to load collection from repository.
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromRepository(IBookStorage storage)
        {
            if (storage == null) throw new ArgumentException("Storage can't be null.");

            _books = new SortedSet<Book>(storage.Read());
        }

        #endregion
    }
}
