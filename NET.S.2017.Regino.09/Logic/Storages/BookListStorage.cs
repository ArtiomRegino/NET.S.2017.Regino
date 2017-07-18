using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Storages
{
    /// <summary>
    /// Class for BookListStorage for binary reading and writing to storage. 
    /// </summary>
    class BookListStorage : IBookStorage
    {
        private readonly string pathToFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        public BookListStorage(string pathToFile)
        {
            if (pathToFile == null) throw new ArgumentException("");

            this.pathToFile = pathToFile;
        }

        /// <summary>
        /// Method for saving collection of books by BinaryWriter. 
        /// </summary>
        /// <param name="books">Collection of books.</param>
        public void Save(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(pathToFile)))
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

        /// <summary>
        /// Method for reading collection of books by BinaryReader. 
        /// </summary>
        /// <returns>Collection that was read.</returns>
        public IEnumerable<Book> Read()
        {
            SortedSet<Book> books = new SortedSet<Book>();
            string title, author, ganre;
            int year, edition;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(pathToFile)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    title =  reader.ReadString();
                    author = reader.ReadString();
                    ganre = reader.ReadString();
                    year = reader.ReadInt32();
                    edition = reader.ReadInt32();

                    books.Add(new Book(title, author, ganre, year, edition));
                }
            }

            return books;
        }
    }
}
