using System;
using System.Globalization;

namespace Logic
{
    /// <summary>
    /// Class that describes a book.
    /// </summary>
    public class Book: IComparable, IEquatable<Book>, IFormattable, IComparable<Book>
    {
        private string _author;
        private string _genre;
        private string _title;
        private int _year;
        private int _edition;

        #region Properties

        /// <summary>
        /// Author.
        /// </summary>
        public string Author
        {
            get{ return _author; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException($"Author must have a value.");
                _author = value;
            }
        }

        /// <summary>
        /// Genre.
        /// </summary>
        public string Genre
        {
            get { return _genre; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException($"Genre must have a value.");
                _genre = value;
            }
        }

        /// <summary>
        /// Author.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException($"Title must have a value.");
                _title = value;
            }
        }

        /// <summary>
        /// Year.
        /// </summary>
        public int Year
        {
            get { return _year; }
            set {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"Value of year can't be 0 or less.");
                _year = value;
            }
        }

        /// <summary>
        /// Edition.
        /// </summary>
        public int Edition
        {
            get { return _edition; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"Value of edition can't be 0 or less.");
                _edition = value;
            }
        }

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
            Title = title;
            Author = author;
            Genre = genre;  
            Year = year;
            Edition = edition;
        }

        #endregion

        #region Methods

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

            return hash; 
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Book other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Author == other.Author &&
                   Genre == other.Genre &&
                   Title == other.Title &&
                   Year == other.Year &&
                   Edition == other.Edition;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Book) obj);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object obj)
        {
            if (GetType() != obj.GetType())
                throw new ArgumentException("Incorrect type in comparison.");

            return CompareTo((Book) obj);
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

            return Equals(this, book) ? 0 : string.Compare(Title, book.Title, StringComparison.Ordinal);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>A string that represents the current object.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
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
                
                case "G": return $"Title: {Title} Author: {Author} Genre: {Genre} Year: {Year} Edition: {Edition}".ToString(formatProvider);
                case "T": return $"Title: {Title}".ToString(formatProvider);
                case "A": return $"Title: {Title} Author: {Author}".ToString(formatProvider);
                default: throw new FormatException($"The {format} format string is not supported.");
            }

        }
        
        #endregion
    }
}
