using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerFormat.NunitTests
{
    [TestFixture]
    class CustomerProviderTests
    {
        
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, ExpectedResult = true)]
        public bool ToString_PositiveTest(string name, string phone, decimal revenue)
        {
            CustomerProvider provider = new CustomerProvider();
            Customer customer = new Customer(name, phone, revenue);
            bool answer = true;

            if (String.Format(provider, "{0:t}", customer) != $"Requested data about customer {customer.Name}: Phone: {customer.ContactPhone}, Revenue:{customer.Revenue}") answer = false;
            if (String.Format(provider, "{0:p}", customer) != $"Customer's phone: {customer.ContactPhone }") answer = false;

            return answer;
        }
    }
}
