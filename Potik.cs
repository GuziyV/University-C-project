using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navch
{
    class Potik
    {
        private List<Group> groupList = new List<Group>();

        public void addGroup(Group g)
        {
            groupList.Add(g);
        }
        public void WriteStudentsToFile(string filePath)
        {
            foreach (Group g in groupList)
            {
                g.WriteStudentsToFile(filePath);
            }
        }

        public void addStudent(Student st, int group)
        {
            groupList[group].Add(st);
        }
        public void Sort()
        {
            foreach (Group g in groupList)
            {
                g.Sort();
            }
        }
        public void ReadStudentsFromFile(string filePath)
        {
            groupList = new List<Group>();
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                string line;
                sr.ReadLine();
                Group g = new Group();
                while ((line = sr.ReadLine()) != null)
                {
                    if ((line) == "Group:")
                    {
                        groupList.Add(g);
                        g = new Group();
                        continue;
                    }
                    string[] parsed = ParseStringFromFile(line);
                    if (parsed.Length == 6)
                    {
                        g.Add(new Graduate(parsed[0], parsed[1], parsed[2], parsed[3], parsed[5]));
                    }
                    else
                    {
                        g.Add(new Student(parsed[0], parsed[1], parsed[2], parsed[3]));
                    }

                }
                groupList.Add(g);
            }
        }


        private string[] ParseStringFromFile(string line)
        {
            string[] res = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return res;
        }
        public void display()
        {
            this.Sort();
            foreach (Group g in groupList)
            {
                g.displayGroup();
            }
        }
    }
}
