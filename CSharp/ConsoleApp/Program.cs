using ConsoleApp.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new BuildInDelegatesExample();

            example.Test();
            Console.ReadKey();
        }
    }
}