using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobertGreenTest
{
    public class Customer : ObjectsManager<Customer>
    {
        public string FirstName;
        public string LastName;
        public Address Address;

        public Customer()
        {

        }

        public Customer(string name, string lastName, Address address)
        {
            this.FirstName = name;
            this.LastName = lastName;
            if (!address.IsSaved())
            {
                address.Save();
            }
            this.Address = address;

        }
    }
}
