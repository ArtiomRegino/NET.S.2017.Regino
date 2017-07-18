using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Book: IComparable, IEquatable<Book>, IFormattable
    {

        public string Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Edition { get; set; }

        public Book(string title, string author, string genre, int year, int edition)
        {
            ConstuctorValidation(author, genre, title, year, edition);
            Title = title;
            Author = author;
            Genre = genre;  
            Year = year;
            Edition = edition;
        }

        private void ConstuctorValidation(string author, string genre, string title, int year, int edition)
        {
            if (String.IsNullOrEmpty(author))
                throw new ArgumentException();
            if (String.IsNullOrEmpty(genre))
                throw new ArgumentException();
            if (String.IsNullOrEmpty(title))
                throw new ArgumentException();
            if (year <= 0 || edition <= 0)
                throw new ArgumentOutOfRangeException("");
        }

        public override int GetHashCode()
        {
            int hash = Title.GetHashCode();

            hash += Author.GetHashCode();
            hash += 5 * Genre.GetHashCode();
            hash += 3 * Year;
            hash += 3 * Edition;

            return hash; ;
        }

        public bool Equals(Book other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;

            if (Author == other.Author &&
            Genre == other.Genre &&
            Title == other.Title &&
            Year == other.Year &&
            Edition == other.Edition)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return base.Equals((Book) obj);
        }

        public int CompareTo(object obj)
        {
            if (this.GetType() != obj.GetType())
                throw new ArgumentException("");

            return this.CompareTo((Book) obj);
        }

        public int CompareTo(Book book)
        {
            //By definition, any string, including the empty string (""), compares greater than a null reference; and two null references compare equal to each other.
            if (book == null) return 1;
            if (object.ReferenceEquals(this, book)) return 0;

            return String.Compare(this.Title, book.Title, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            if(formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format)
            {
                case "G": return $"Title: {Title} Author: {Author} Genre: {Genre} Year: {Year} Edition: {Edition}";
                case "T": return $"Title: {Title}";
                case "A": return $"Title: {Title} Author: {Author}";
                default: throw new FormatException($"The {format} format string is not supported.");
            }

        }
    }
}
