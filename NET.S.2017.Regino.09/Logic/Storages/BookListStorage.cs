using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Storages
{
    class BookListStorage : IBookStorage
    {
        private readonly string pathToFile;


        public BookListStorage(string pathToFile)
        {
            if (pathToFile == null) throw new ArgumentException("");

            this.pathToFile = pathToFile;
        }


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

        public IEnumerable<Book> Read()
        {
            SortedSet<Book> books = new SortedSet<Book>();
            string title, author, genre;
            int year, edition;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(pathToFile)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    title =  reader.ReadString();
                    author = reader.ReadString();
                    genre = reader.ReadString();
                    year = reader.ReadInt32();
                    edition = reader.ReadInt32();

                    books.Add(new Book(title, author, genre, year, edition));
                }
            }

            return books;
        }
    }
}
