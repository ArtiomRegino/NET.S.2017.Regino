using Logic.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Loggers;

namespace Logic
{
    /// <summary>
    /// Service for working with a collection of books.
    /// </summary>
    public class BookListService
    {
        private readonly ILogger _logger;
        private SortedSet<Book> _books;

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
            _logger = new CustomLogger();
            _books = new SortedSet<Book>();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="logger">The instance of custom logger.</param>
        public BookListService(ILogger logger)
        {
            if (logger == null)
                _logger = new CustomLogger();

            _logger = logger;
            _books = new SortedSet<Book>();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="collection">Collection of books.</param>
        /// <param name="logger">The instance of custom logger.</param>
        /// <exception cref="ArgumentNullException">Throws when logger or collection is null.</exception>
        public BookListService(IEnumerable<Book> collection, ILogger logger)
        {
            if(logger == null)
                throw new ArgumentNullException($"{nameof(logger)} can't be null.");
            _logger = logger;
            try
            {
                if (collection == null)
                    throw new ArgumentNullException(nameof(collection), "Collection can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _books = new SortedSet<Book>(collection);
        }

        #endregion

        #region Functionality

        /// <summary>
        /// Method for adding a book to collection.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="ArgumentNullException">Throws when book is null.</exception>
        /// <exception cref="ArgumentException">Throws when book is already exists.</exception>
        public void AddBook(Book book)
        {
            try
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book), "Book can't be null.");
                if (!_books.Add(book))
                    throw new ArgumentException("This book already exists.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            catch (ArgumentException ex)
            {
                _logger.Warn(ex.ToString());
                return;
            }

            _logger.Info($"Book was added: {book}");

        }

        /// <summary>
        /// Method for removing a book from collection.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        /// <exception cref="ArgumentNullException">Throws when book is null.</exception>
        /// <exception cref="ArgumentException">Throws when there's no such book.</exception>
        public void RemoveBook(Book book)
        {
            try
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book), "Book can't be null.");
                if (!_books.Remove(book))
                    throw new ArgumentException("There's no such book.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            catch (ArgumentException ex)
            {
                _logger.Warn(ex.ToString());
                return;
            }

            _logger.Info($"Book was removed: {book}");
        }

        /// <summary>
        /// Find the book according to the specified criteria.
        /// </summary>
        /// <param name="predicate">Delegate to receive criteria.</param>
        /// <returns>Book according to criteria.</returns>
        /// <exception cref="ArgumentNullException">Throws when book or delegate is null.</exception>
        public Book FindBookByTag(Predicate<Book> predicate)
        {
            try
            {
                if (predicate == null) throw new ArgumentNullException(nameof(predicate), "Predicat can't be null.");

                foreach (var book in _books.Where(book => predicate(book)))
                {
                    if (book == null) throw new ArgumentNullException(nameof(book), "Book can't be null.");
                    return new Book(book.Title, book.Author, book.Genre, book.Year, book.Edition);
                }
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _logger.Info($"Searching according to the specified criteria was successful.");

            return null;
        }

        /// <summary>
        /// Find the book according to the specified criteria.
        /// </summary>
        /// <param name="predicate">Delegate to receive criteria.</param>
        /// <returns>Collection of books according to criteria.</returns>
        /// <exception cref="ArgumentNullException">Throws when delegate is null.</exception>
        public IEnumerable<Book> FindBooksByTag(Predicate<Book> predicate)
        {
            try
            {
                if (predicate == null) throw new ArgumentNullException(nameof(predicate), "Predicate can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _logger.Info($"Searching according to the specified criteria was successful.");

            return _books.Where(book => predicate(book));
        }

        /// <summary>
        /// Sort books according to the specified criteria.
        /// </summary>
        /// <param name="comparer">Comparer to specify the sorting criteria.</param>
        /// <exception cref="ArgumentNullException">Throws when comparer is null.</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            try
            {
                if (comparer == null) throw new ArgumentNullException(nameof(comparer), "Comparer can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _books = new SortedSet<Book>(collection: _books, comparer: comparer);
            _logger.Info($"Sorting complited.");
        }

        #endregion

        #region Methods For Repository

        /// <summary>
        /// Method to save collection to repository.
        /// </summary>
        /// <param name="storage">Repository.</param>
        /// <exception cref="ArgumentNullException">Throws when storage is null.</exception>
        public void SaveToRepository(IBookStorage storage)
        {
            try
            {
                if (storage == null) throw new ArgumentNullException(nameof(storage), "Storage can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            storage.Save(_books);
            _logger.Info($"Data was saved.");
        }

        /// <summary>
        /// Method to load collection from repository.
        /// </summary>
        /// <param name="storage"></param>
        /// <exception cref="ArgumentNullException">Throws when storage is null.</exception>
        public void LoadFromRepository(IBookStorage storage)
        {
            try
            {
                if (storage == null) throw new ArgumentNullException(nameof(storage), "Storage can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _books = new SortedSet<Book>(storage.Read());
            _logger.Info($"Loading complited.");
        }

        #endregion
    }
}
