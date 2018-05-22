using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navch
{
    sealed class Graduate : Student
    {
        private string graduation;

        public string Graduation
        {
            get
            {
                return graduation;
            }
            set
            {
                graduation = value;
            }
        }

        public Graduate(string surname, string name, string gender, string dateOfBirth, string graduation) :
            base(surname, name, gender, dateOfBirth)
        {
            Graduation = graduation;
        }
        public override string ToString()
        {
            return String.Format("{0,-15}{1,-15}{2,-10}{3,-15}{4,-10}{5, -10}", Surname, Name, Gender, DateOfBirth.ToShortDateString(), NumerOfYears, Graduation);
        }
    }
}
