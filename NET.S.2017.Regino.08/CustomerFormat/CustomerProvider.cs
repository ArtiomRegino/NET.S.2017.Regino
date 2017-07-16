using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    /// <summary>
    /// Class thet provides format of presentaishion for class Customer.
    /// </summary>
    public class CustomerProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return</param>
        /// <returns>An instance of the object specified by formatType, if the IFormatProvider implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>The string representation of the value of arg, formatted as specified by format and formatProvider.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null)) throw new ArgumentNullException();
            if (arg.GetType() != typeof(Customer))
                try {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e) {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }

            format = format.ToUpper(CultureInfo.InvariantCulture);
            Customer customer = arg as Customer;

            if (!(format == "P" || format == "T"))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e) {
                    throw new FormatException($"The format of '{format}' is invalid.", e);
                }

            switch (format)
            {
                case "P":
                    return $"Customer's phone: {customer.ContactPhone }";
                case "T":
                    return $"Requested data about customer {customer.Name}: Phone: {customer.ContactPhone}, Revenue:{customer.Revenue}";
                default:
                    return string.Empty;
            }
        }
       
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
