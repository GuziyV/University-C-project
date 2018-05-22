using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navch
{
    class Group : IEnumerable<Student>
    {
        private Action showMessage;
        private Student deleted = null;
        private List<Student> students;
        public Group()
        {
            students = new List<Student>();
            showMessage += showDeletedStudentInfo;
            showMessage += displayGroup;
        }
        private string[] ParseStringFromFile(string line)
        {
            //line = line.Replace(" ", string.Empty);
            return line.Split(' ');
        }

        public void Add(Student s)
        {
            students.Add(s);
        }

        public void Sort()
        {
            students.Sort();
        }

        public void Clear()
        {
            students.Clear();
        }

        public void ReadStudentsFromFile(string filePath)
        {
            students.Clear();
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                string line;
                sr.ReadLine(); //Group:
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parsed = ParseStringFromFile(line);
                    if (parsed.Length == 6)
                    {
                        students.Add(new Graduate(parsed[0], parsed[1], parsed[2], parsed[3], parsed[5]));
                    }
                    else
                    {
                        students.Add(new Student(parsed[0], parsed[1], parsed[2], parsed[3]));
                    }
                }
            }
        }

        public void WriteStudentsToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine("Group:");
                for (int i = 0; i < students.Count; i++)
                {
                    sw.WriteLine(students[i].ToString());
                }
            }
        }

        public bool DeleteStudet(string surname)
        {
            Student remove = students.FirstOrDefault(s => s.Surname == surname);
            if(remove == null)
            {
                return false;
            }
            deleted = remove;
            students.Remove(remove);
            if(deleted != null)
            {
                showMessage();
            }
            deleted = null;
            return true;
        }

        public void displayGroup()
        {
            Console.WriteLine("Group:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
        }

        private void showDeletedStudentInfo()
        {
            Console.WriteLine("deleted student:");
            Console.WriteLine(deleted);
        }

        public void deleteStudent(string surname)
        {


        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
}
