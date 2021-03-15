using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public record Person
    {
    public string LastName { get; }
    public string FirstName { get; }
    public Address Address { get; }
    public Person(string first, string last, Address address) => (FirstName, LastName, Address) = (first, last, address);
    }

    public class Address
    {
        public string Name { get; }
        public string FirstName { get; }

        public Address(string name)
        {
            Name = name;
        }
    }


}
