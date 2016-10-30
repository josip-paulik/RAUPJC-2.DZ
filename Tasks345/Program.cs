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

            Console.ReadLine();
        }
    }
}
