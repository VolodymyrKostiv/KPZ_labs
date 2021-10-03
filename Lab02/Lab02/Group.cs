using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Group
    {
        static int IDcounter = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Group(string name, List<Student> students)
        {
            ID = IDcounter++;
            Name = name;
            Students = students;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public override string ToString()
        {
            string res = "";
            foreach (Student student in Students)
                res += student.ToString() + "\n";
            return res;
        }
    }

    public static class GroupExtension
    {
        public static void PrintGroup(this Group group)
        {
            foreach (var student in group.Students)
                Console.WriteLine(student);
        }
    }
}
