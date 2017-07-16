using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerFormat.NunitTests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, ExpectedResult = true)]
        [TestCase("Richard Dawkins", "+1 (230) 336 538", 70, ExpectedResult = true)]
        public bool ToString_PositiveTest(string name, string phone, decimal revenue)
        {
            Customer customer = new Customer(name, phone, revenue);
            bool answer = true;

            if (customer.ToString("G", CultureInfo.CurrentCulture) != $"Customer: {name}, Phone: {phone}, Revenue:{revenue.ToString("C", CultureInfo.CurrentCulture)}") answer = false;
            if (customer.ToString("k", CultureInfo.CurrentCulture) != $"Customer: {name},  Phone: {phone}") answer = false;
            if (customer.ToString("b", CultureInfo.CurrentCulture) != $"Customer: {name}, Revenue:{revenue.ToString("C", CultureInfo.CurrentCulture)}") answer = false;
            if (customer.ToString("S", CultureInfo.CurrentCulture) != $"Customer: {name}") answer = false;
            if (customer.ToString("R", CultureInfo.CurrentCulture) != $"Customer: {revenue.ToString("C", CultureInfo.CurrentCulture)}") answer = false;

            return answer;
        }
    }
}
