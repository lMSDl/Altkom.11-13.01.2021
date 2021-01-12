using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpression
{
    public class LinqExample
    {
        int[] numbers = new[] { 1, 3, 4, 2, 5, 7, 8, 6, 9, 0 };
        List<string> strings = "wlazł kotek na płotek i mruga".Split(' ').ToList();

        List<Student> students = new List<Student>
        {
            new Student { FirstName = "Adam", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1990, 1, 1), Gender = Gender.Female  } ,
            new Student { FirstName = "Adam", LastName = "Ewowska", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Ewa", LastName = "Adamska", BirthDate = new DateTime(1990, 1, 1), Gender = Gender.Female  } ,
            new Student { FirstName = "Piotr", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Kamila", LastName = "Ewowska", BirthDate = new DateTime(1990, 1, 1), Gender = Gender.Female  } ,
    };

        public void Test()
        {
            var queryResult1 = from number in numbers
                               where number > 4
                               select number;
            var queryResult2 = numbers.Where(x => x > 4).ToList();

            var queryResult3 = numbers.Where(x => x > 4).OrderBy(x => x).ToList();

            var queryResult4 = strings.Where(x => x.Length == 5).Select(x => x.ToUpper());

            var queryResult5 = students.Where(x => x.LastName == "Adamski").Select(x =>

            //string.Format("{1} {0} | {2}", x.FirstName, x.LastName, x.Gender)
            $"{x.FirstName} {x.LastName} | {x.Gender}"
            
            ).ToList();



        }

    }
}
