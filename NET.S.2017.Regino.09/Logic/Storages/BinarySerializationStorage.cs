using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Logic.Storages
{
    class BinarySerializationStorage: IBookStorage
    {
        private readonly ILogger _logger;
        private readonly string _pathToFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        /// <param name="logger">The instance of custom logger.</param>
        /// <exception cref="ArgumentNullException">Path to file and logger can't be null.</exception>
        public BinarySerializationStorage(string pathToFile, ILogger logger)
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
        /// Method for saving collection of books using binary serialization. 
        /// </summary>
        /// <param name="books">Collection of books.</param>
        public void Save(IEnumerable<Book> books)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (Stream stream = File.OpenWrite(_pathToFile))
                {
                    binaryFormatter.Serialize(stream, books);
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
        /// Method for reading collection of books using binary deserialization. 
        /// </summary>
        /// <returns>Collection that was read.</returns>
        public IEnumerable<Book> Read()
        {
            SortedSet<Book> books;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using (Stream stream = new FileStream(_pathToFile, FileMode.Open))
                {
                    books = (SortedSet<Book>) binaryFormatter.Deserialize(stream);
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
