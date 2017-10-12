using CheckData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Checking.CheckEmailAddress("sldfj@ldksjf.com"));
            Console.WriteLine(Checking.CheckPass("Qwerty77"));
            Console.WriteLine(Checking.CheckName("Vlad"));
        }
    }
}
