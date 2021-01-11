using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class BuildInDelegatesExample
    {
        public event EventHandler<OddNumberEventArgs> OddNumberEvent;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                OddNumberEvent?.Invoke(this, new OddNumberEventArgs { Result = result});
        }

        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

        private int _counter = 0;
        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            OddNumberEvent += BuildInDelegatesExample_OddNumberEvent;
            OddNumberEvent += BuildInDelegatesExample_OddNumberEvent1;

            var add = new Action<int, int>(Add);
            var substract = new Func<int, int, bool>(Substract);
            Method(add, substract);
            Console.WriteLine("Number of odd numbers: " + _counter);
        }

        private void BuildInDelegatesExample_OddNumberEvent1(object sender, OddNumberEventArgs e)
        {
            Console.WriteLine("** Odd number detected **: " + e.Result);
        }

        private void BuildInDelegatesExample_OddNumberEvent(object sender, EventArgs e)
        {
            CountOddNumbers();
        }

        //public delegate void AddDelegate(int a, int b);
        //public delegate bool SubstractDelegate(int a, int b);
        //public void Method(AddDelegate add, SubstractDelegate sub)
        public void Method(Action<int, int> add, Func<int, int, bool> sub)
        {
            for (var i = 0; i < 3; i++)
                for (var ii = 0; ii < 3; ii++)
                {
                    add(i, ii);
                    if (sub(i, ii))
                        OddNumberEvent?.Invoke(this, new OddNumberEventArgs());
                }
        }

        public class OddNumberEventArgs : EventArgs
        {
            public int? Result { get; set; }
        }
    }
}
