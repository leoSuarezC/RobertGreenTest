﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertGreenTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new Address("add 1");
            address.Save();
            Console.WriteLine(address);
        }
    }
}
