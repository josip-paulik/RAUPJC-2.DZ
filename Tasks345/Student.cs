using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks345
{
    public enum Gender
    {
        Male, Female
    }

    public class Student : IEquatable<Object>
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        #region Overriding operators == and != between 2 students

        public static bool operator ==(Student s1, Student s2)
        {
            if (s1.Name.Equals(s2.Name) && s1.Jmbag.Equals(s2.Jmbag))
                return true;
            else
                return false;
        }

        public static bool operator !=(Student s1, Student s2)
        {
            if (s1.Name.Equals(s2.Name) && s1.Jmbag.Equals(s2.Jmbag))
                return false;
            else
                return true;
        }

        #endregion

        #region overriding GetHashCode and Equals method

        public override bool Equals(Object other)
        {
            if (Object.ReferenceEquals(null, other))
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            if (!(other is Student))
                return false;

            Student otherStudent= (Student)other;

            return this.Jmbag.Equals(otherStudent.Jmbag) && this.Name.Equals(otherStudent.Name);
        }

        public override int GetHashCode()
        {
            int hashCodeName = 0;
            if (this.Name != null)
                hashCodeName = this.Name.GetHashCode();

            int hashCodeJmbag = 0;
            if (this.Jmbag == null)
                hashCodeJmbag = this.Jmbag.GetHashCode();

            return hashCodeName ^ hashCodeJmbag;
        }

        #endregion
    }
}
