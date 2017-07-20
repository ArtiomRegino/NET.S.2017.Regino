using System;
using System.Collections.Generic;
using System.IO;

namespace Logic.Storages
{
    /// <summary>
    /// Class for BookListStorage for binary reading and writing to storage. 
    /// </summary>
    public class BookListStorage : IBookStorage
    {
        private readonly ILogger _logger;
        private readonly string _pathToFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        /// <param name="logger">The instance of custom logger.</param>
        /// <exception cref="ArgumentNullException">Path to file and logger can't be null.</exception>
        public BookListStorage(string pathToFile, ILogger logger)
        {
            try
            {
                if (pathToFile == null)
                    throw new ArgumentNullException(nameof(pathToFile), "Path to file can't be null.");
                if (logger == null) throw new ArgumentNullException(nameof(logger), "Logger can't be null.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _pathToFile = pathToFile;
            _logger = logger;
        }

        /// <summary>
        /// Method for saving collection of books by BinaryWriter. 
        /// </summary>
        /// <param name="books">Collection of books.</param>
        public void Save(IEnumerable<Book> books)
        {
            try
            {
                using (var writer = new BinaryWriter(File.OpenWrite(_pathToFile)))
                {
                    foreach (var item in books)
                    {
                        writer.Write(item.Title);
                        writer.Write(item.Author);
                        writer.Write(item.Genre);
                        writer.Write(item.Year);
                        writer.Write(item.Edition);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _logger.Info($"Saving to file: {_pathToFile}.");
        }

        /// <summary>
        /// Method for reading collection of books by BinaryReader. 
        /// </summary>
        /// <returns>Collection that was read.</returns>
        public IEnumerable<Book> Read()
        {
            var books = new SortedSet<Book>();
            string title, author, ganre;
            int year, edition;

            try
            {
                using (var reader = new BinaryReader(File.OpenRead(_pathToFile)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        title = reader.ReadString();
                        author = reader.ReadString();
                        ganre = reader.ReadString();
                        year = reader.ReadInt32();
                        edition = reader.ReadInt32();

                        books.Add(new Book(title, author, ganre, year, edition));
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            _logger.Info($"Loading from the file: {_pathToFile}.");
            return books;
        }
    }
}
