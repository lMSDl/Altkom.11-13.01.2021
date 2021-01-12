using ConsoleApp.Delegates;
using ConsoleApp.Indexers;
using ConsoleApp.LambdaExpression;
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
            var example = new IndexerExample();

            example.Test();
            Console.ReadKey();
        }

        static void Abc()
        {
            Nullable<int> a = null;
            int? b = 5;
            int c;

            if(a - b == 0)
            {
                c = (a + b) ?? 0;
            }
            else
            {
                var result = a - b;
                //if (result != null)
                if(result.HasValue)
                    c = result.Value;
                else
                    c = 0;
            }

            c = (a - b == 0 ? a + b : a - b) ?? 0;
        }
    }
}
