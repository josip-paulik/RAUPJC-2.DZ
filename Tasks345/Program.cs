using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks345
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3rd task

            int[] integers = new[] {1, 2, 2, 2, 3, 3, 4, 5};

            
            string[] strings = integers.GroupBy(
                     ints => ints,
                     (ints, array) => "Broj " + ints + " se pojavljuje " + array.Count() + " puta."
                     )
                     .ToArray();

            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }

            #endregion

            #region 4th task

            Console.WriteLine(Example1() + " " + Example2());

            #endregion
            Console.ReadLine();
        }

        static bool Example1()
        {
            var list = new List<Student>() { new Student("Ivan", jmbag: "001234567") };
            var ivan = new Student("Ivan", jmbag: "001234567");
            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
            return anyIvanExists;
        }

        static int Example2()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };
            // 2 :(

            var distinctStudents = list.Distinct().Count();

            return distinctStudents;
        }
    }
}
