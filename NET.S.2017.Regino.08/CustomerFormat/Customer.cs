using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    /// <summary>
    /// Class that represent customer.
    /// </summary>
    public class Customer: IFormattable
    {
        
        private string name;
        private string contactPhone;

        /// <summary>
        /// Property for customer's revenue.
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// Property for customer's name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException();
                name = value;
            }
        }

        /// <summary>
        /// Property for customer's phone.
        /// </summary>
        public string ContactPhone
        {
            get { return contactPhone; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException();
                contactPhone = value;
            }
        }

        /// <summary>
        /// Conrustor.
        /// </summary>
        /// <param name="name">Name of customer.</param>
        /// <param name="phone">Phone of customer.</param>
        /// <param name="revenue">Revenue of customer.</param>
        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = phone;
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
        /// Returns a string that represents the current object using the specified format.
        /// </summary>
        /// <param name="format">Formats the value of the current instance.</param>
        /// <returns>A string that represents the current object.</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">Formats the value of the current instance using the specified format.</param>
        /// <param name="provider">The provider to use to format the value.</param>
        /// <returns>The value of the current instance in the specified format.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G": return $"Customer: {Name}, Phone: {ContactPhone}, Revenue:{Revenue.ToString("C", provider)}";
                case "K": return $"Customer: {Name},  Phone: {ContactPhone}";
                case "B": return $"Customer: {Name}, Revenue:{Revenue.ToString("C", provider)}";
                case "S": return $"Customer: {Name}";
                case "R": return $"Customer: {Revenue.ToString("C", provider)}";
                default: return "Customer.";
            }
        }

        
    }
}
