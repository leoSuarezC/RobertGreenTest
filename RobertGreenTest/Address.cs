using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertGreenTest
{
    public class Address : ObjectsManager<Address>
    {

        public string addr1;
        public string addr2;
        public string code;
        public string zip;
        public Address(string addr1, string addr2, string code, string zip)
        {
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.code = code;
            this.zip = zip;

        }

        public Address()
        {

        }

    }
}
