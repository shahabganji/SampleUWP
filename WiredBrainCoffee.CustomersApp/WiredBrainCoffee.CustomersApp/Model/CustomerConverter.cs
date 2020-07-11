using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.Model
{
    public static class CustomerConverter
    {
        public static Customer CreateFromString(string inputString)
        {
            var values = inputString.Split(",").Select(v => v.Trim()).ToImmutableArray();
            var customer = new Customer
            {
                FirstName = values[0], LastName = values[1], IsDeveloper = bool.Parse(values[2])
            };

            return customer;
        }
    }
}