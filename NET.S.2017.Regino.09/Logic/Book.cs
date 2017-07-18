using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Class that describes a book.
    /// </summary>
    public class Book: IComparable, IEquatable<Book>, IFormattable
    {
        #region Properties

        /// <summary>
        /// Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Author.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Edition.
        /// </summary>
        public int Edition { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="author">Author.</param>
        /// <param name="genre">Genre.</param>
        /// <param name="year">Year.</param>
        /// <param name="edition">Edition.</param>
        public Book(string title, string author, string genre, int year, int edition)
        {
            ConstuctorValidation(author, genre, title, year, edition);
            Title = title;
            Author = author;
            Genre = genre;  
            Year = year;
            Edition = edition;
        }

        #endregion

        #region Methods

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

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hash = Title.GetHashCode();

            hash += Author.GetHashCode();
            hash += 5 * Genre.GetHashCode();
            hash += 3 * Year;
            hash += 3 * Edition;

            return hash; ;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return base.Equals((Book) obj);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object obj)
        {
            if (this.GetType() != obj.GetType())
                throw new ArgumentException("");

            return this.CompareTo((Book) obj);
        }

        /// <summary>
        /// Compares the current instance with another one.
        /// </summary>
        /// <param name="book">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the instances being compared.</returns>
        public int CompareTo(Book book)
        {
            //By definition, any string, including the empty string (""), compares greater than a null reference; and two null references compare equal to each other.
            if (book == null) return 1;
            if (object.ReferenceEquals(this, book)) return 0;

            return String.Compare(this.Title, book.Title, StringComparison.Ordinal);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>A string that represents the current object.</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <param name="formatProvider">The provider to use to format the value.</param>
        /// <returns>A string that represents the current object.</returns>
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
        
        #endregion
    }
}
