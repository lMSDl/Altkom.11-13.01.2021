using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpression
{
    public class LambdaExamples
    {
        Func<int, int, int> Calculator { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        public void Test()
        {
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(a, b) => { return a + b; };
                          (a, b) => a + b;

            SomeAction += //(a) => Console.WriteLine(a);
                          a => Console.WriteLine(a);

            AnotherAction += () => Console.WriteLine("Action!");

            SomeMethod(x =>
           {
               var @string = x.Replace(",", "'");
               Console.WriteLine(@string);
           },
            "ABC,BCD,CDE");
        }

        void SomeMethod(Action<string> stringAction, string @string)
        {
            stringAction(@string);
        }
    }
}
