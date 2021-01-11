using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class DelegateExample
    {
        public delegate void NoParametersNoReturnDelegate();
        public delegate void NoReturnDelegate(string @string);
        public delegate bool ParametersDelegate(int x, int y);

        public void Func1()
        {
            Console.WriteLine("1");
        }

        public void Func2(string someString)
        {
            Console.WriteLine(someString);
        }

        public bool Func3(int x, int y)
        {
            Console.WriteLine($"{nameof(Func3)}: {x} {y}");
            return x == y;
        }

        ParametersDelegate Delegate3 { get; set; }

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnDelegate(Func1);

            //if(delegate1 != null)
            //    delegate1();
            delegate1?.Invoke();

            NoReturnDelegate delegate2 = null;
            delegate2 = Func2;
            delegate2("2");

            Delegate3 = Func3;
            for (var i = 0; i < 3; i++)
                if (Delegate3(1, i))
                    Console.WriteLine("==");
        }
    }
}
