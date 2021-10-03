using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Subject
    {
        static int IDcounter = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Subject(string name, int credits = 6)
        {
            ID = IDcounter++;
            Name = name;
            Credits = credits;
        }

        public override string ToString()
        {
            return $"ID = {ID}\tName = {Name}\tCredits = {Credits}";
        }
    }
}
