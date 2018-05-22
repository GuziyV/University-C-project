using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navch
{
    class Student : IComparable
    {
        private string name;

        private string surname;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        private string gender;

        public string Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                gender = value;
            }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            private set
            {
                dateOfBirth = value;
            }
        }

        public int NumerOfYears
        {
            get
            {
                return DateTime.Now.AddYears(-dateOfBirth.Year).AddMonths(-dateOfBirth.Month).AddDays(-DateOfBirth.Day).Year;
            }
        }

        public Student(string surname, string name, string gender, string dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            DateOfBirth = DateTime.Parse(dateOfBirth);
        }

        public int CompareTo(object obj)
        {
            return this.DateOfBirth.CompareTo(((Student)obj).DateOfBirth);
        }

        public override string ToString()
        {
            return String.Format("{0,-15}{1,-15}{2,-10}{3,-15}{4,-10}", Surname, Name, Gender, DateOfBirth.ToShortDateString(), NumerOfYears);
        }
    }
}
