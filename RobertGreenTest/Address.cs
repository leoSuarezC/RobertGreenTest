using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertGreenTest
{
    class Address : ObjectsManager
    {
        private string _name;

        public Address(string name = "")
        {
            _name = name;
        }
    }
}
