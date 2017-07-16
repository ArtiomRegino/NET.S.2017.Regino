using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat
{
    public class Customer: IFormattable
    {
        
        private string name;
        private string contactPhone;
        public decimal Revenue { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException();
                name = value;
            }
        }

        public string ContactPhone
        {
            get { return contactPhone; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException();
                contactPhone = value;
            }
        }

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            Revenue = revenue;
            ContactPhone = phone;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

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
