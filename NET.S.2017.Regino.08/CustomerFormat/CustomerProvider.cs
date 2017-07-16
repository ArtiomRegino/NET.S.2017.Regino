using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    class CustomerProvider : IFormatProvider, ICustomFormatter
    {

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

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
                    return $"Customer's phone:{customer.ContactPhone }";
                case "T":
                    return $"Requested data about customer {customer.Name}: Phone: {customer.ContactPhone}, Revenue:{customer.Revenue})";
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
