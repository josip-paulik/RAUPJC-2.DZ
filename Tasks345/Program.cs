using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            #region 5th task

            University[] universities = GetAllCroatianUniversities();

            Student[] allCroatianStudents = universities.SelectMany(u => u.Students).Distinct().ToArray();

            //Brilliantly complicated simple soultion... so I think...
            //this solution assumes that universites collection has unique members
            //solution could be better
            Student[] croatianStudentsOnMultipleUniversites = universities.SelectMany(u => u.Students) // get all students and throw them into single collection
                                                                          .GroupBy
                                                                          (     // this is very similar to 3rd task

                                                                                // group all students by students...
                                                                                student => student,
                                                                                // ...and for each key, extract how many times it appears in single collection...
                                                                                // ...created by SelectMany
                                                                                (student, studentsArray) => new {Student = student, Count = studentsArray.Count() } 
                                                                          )
                                                                          .Where(studentsArray => studentsArray.Count > 1) //if a student appears more than once, he is going to multiple universities
                                                                          .Select(studentsElement => studentsElement.Student) //select only its name
                                                                          .ToArray(); //throw into array so it can be Student[] compactible
            
            Student[] studentsOnMaleOnlyUniversities = universities.Select(u => u.Students) //select all collections of universites' students
                                                                   .Where(students => AreAllMale(students)) //check if a collection holds all male students(shortcut)
                                                                   .SelectMany(students => students) //throw all students into array
                                                                   .Distinct() //there may be more students...
                                                                   .ToArray(); 


            Console.WriteLine("All croatian students:");
            foreach (var student in allCroatianStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Croatian students on multiple universitites:");
            foreach (var student in croatianStudentsOnMultipleUniversites)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Students on male only universities:");
            foreach (var student in studentsOnMaleOnlyUniversities)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();
            #endregion
            Console.ReadLine();
        }

        private static bool AreAllMale(Student[] students)
        {
            foreach (var student in students)
            {
                if (student.Gender == Gender.Female)
                    return false;
            }

            return true;
        }


        private static University[] GetAllCroatianUniversities()
        {
            #region Students

            Student[] students = new Student[]
            {
                new Student("Josip Paulik", "91", Gender.Male),
                new Student("Josko Joskic", "125", Gender.Male), 
                new Student("Ivan ivanic", "425", Gender.Male)
            };

            Student[] students2 = new Student[]
            {
                new Student("Josip Paulik", "91", Gender.Male),
                new Student("Ana anicka", "14523", Gender.Female),
                new Student("Ivana Ivanic Ivanuska", "42131561", Gender.Female),
                new Student("Anja anc", "556845", Gender.Female),
                new Student("Ivan ivanic", "425", Gender.Male)
            };

            #endregion

            University[] universities = new University[]
            {
                new University("FER", students),
                new University("FFZG", students2)
            };

            return universities;
        }

        static bool Example1()
        {
            var list = new List<Student>() { new Student("Ivan", jmbag: "001234567",gender: Gender.Male) };
            var ivan = new Student("Ivan", jmbag: "001234567", gender: Gender.Male);

            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
            return anyIvanExists;
        }

        static int Example2()
        {
            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567", gender: Gender.Male),
                new Student("Ivan", jmbag: "001234567", gender: Gender.Male)
            };

            // 2 :(
            var distinctStudents = list.Distinct().Count();

            return distinctStudents;
        }
    }
}
