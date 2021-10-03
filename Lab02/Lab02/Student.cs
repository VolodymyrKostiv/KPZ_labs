using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Student : IComparable
    {
        static int IDcounter = 1; 
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public Dictionary<Subject, bool> Commissions { get; set; }

        public Student(string name, List<Subject> subjects)
        {
            ID = IDcounter++;
            Name = name;
            Subjects = subjects;
            SetDictionary(subjects);
        }
        private void SetDictionary(List<Subject> subjects)
        {
            Commissions = new Dictionary<Subject, bool>();
            foreach (var sub in subjects)
                Commissions.Add(sub, false);
        }

        public void AddCommission(Subject subject)
        {
            Commissions[subject] = true;
        }
        public void DeleteCommission(Subject subject)
        {
            Commissions[subject] = false;
        }
        public override string ToString()
        {
            return $"ID = {ID}\tName = {Name}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Student student)
                return Name.CompareTo(student.Name);
            else 
                throw new ArgumentException("Wrong object");
        }
    }
}
