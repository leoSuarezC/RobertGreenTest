using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertGreenTest
{
    public class Company : ObjectsManager<Company>
    {
        public string Name;
        public Address Address;
        public Company()
        {

        }

        public Company(string name , Address address)
        {
            this.Name = name;
            if (!address.IsSaved())
            {
                address.Save();
            }
            this.Address = address;

        }
    }
}
