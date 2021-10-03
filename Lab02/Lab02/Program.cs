using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groups = SetTestData();

            //1. Селекція частини інформації (метод Select)
            Console.WriteLine("--- Select ID of all students ---");
            var studentsID = from gr in groups
                             from stud in gr.Students
                             select stud.ID;
                             
            foreach (var student in studentsID)
                Console.Write($"{student} ");

            //2. Вибірка певної інформації(Where)
            Console.WriteLine("\n\n--- Select Name's of students wich starts with 'K' ---");
            var studentsWithK = from gr in groups
                                from stud in gr.Students
                                where stud.Name.StartsWith("K")
                                select stud.Name;

            foreach (var student in studentsWithK)
                Console.Write($"{student}\n");

            //3. Операції як з списком List так і з словником Dictionary
            Console.WriteLine($"\nNumber of groups = {groups.Count()}");
            Console.WriteLine($"Group with id 4 = {groups.Exists(x => x.ID == 4)}\n");

            Subject compGraphics = groups[0].Students[0].Subjects[0];
            groups.Find(x => 
                x.Name == "PZ-31")
                .Students
                .ForEach(y => y
                .AddCommission(compGraphics));
            groups
                .ForEach(x => x.Students
                .ForEach(y => 
                { 
                    if (y.Commissions.TryGetValue(compGraphics, out bool f) && f) 
                        Console.WriteLine($"{y.Name}, bro..."); 
                }
                ));

            //4. Реалізувати власні методи розширювання
            Console.WriteLine("\nStudents in group 34");
            groups[1].PrintGroup();

            //7. Конвертувати списки в масив.
            Array copyOfGroupList = groups.ToArray();

            //6. Відсортувати за якимось критерієм використовуючи шаблон IComparer
            Console.WriteLine("\n---ID of groups sorted by num of students---");
            Array.Sort(copyOfGroupList, new GroupComparer());
            foreach (Group group in copyOfGroupList)
                Console.Write($"{group.ID} ");

            //5.Показати використання анонімних класів та ініціалізаторів
            var anonymousClass = new { Cringe = true, LabDone = false };

            //8. Відсортувати масив/список за ім’ям чи за кількістю елементів.
            Console.WriteLine("\n\n--- PZ-31 non sorted by name ---");
            Console.WriteLine(groups[0]);

            groups[0].Students.Sort();

            string forcedToUseStringFormat = String.Format("--- PZ-31 sorted by name ---\n{0}", groups[0]);
            Console.WriteLine(forcedToUseStringFormat);

            //?. Групування
            Console.WriteLine("--- Select ID of all students ---");
            var justUsingGroupBy = groups.Where(g => g.Students.Count >= 4).GroupBy(x => x.ID).Select(x => x.Key);

            foreach (var student in justUsingGroupBy)
                Console.Write($"{student} ");

            Console.ReadLine();
        }

        static List<Group> SetTestData()
        {
            Subject subject1 = new Subject("CG");
            Subject subject2 = new Subject("CPP");
            Subject subject3 = new Subject("BD");

            List<Subject> subjects = new List<Subject> { subject1, subject2, subject3 };

            Student student1 = new Student("Krokopiv", subjects);
            Student student2 = new Student("Vilan", subjects);
            Student student3 = new Student("Kysko", subjects);
            Student student4 = new Student("Geras", subjects);
            Student student5 = new Student("Zelenskiy", subjects);
            Student student6 = new Student("Hamanets", subjects);
            Student student7 = new Student("Underground Kindrat", subjects);
            Student student8 = new Student("GigaSimp", subjects);
            Student student9 = new Student("Shpak", subjects);
            Student student10 = new Student("King of Badoo", subjects);
            Student student11 = new Student("AMC Bridge", subjects);
            Student student12 = new Student("Arthas", subjects);

            List<Student> studentsFor1 = new List<Student> { student3, student4, student8, student10 };
            List<Student> studentsFor4 = new List<Student> { student1, student5, student6, student9, student11 };
            List<Student> studentsFor6 = new List<Student> { student2, student7, student12 };

            Group group31 = new Group("PZ-31", studentsFor1);
            Group group34 = new Group("PZ-34", studentsFor4);
            Group group36 = new Group("PZ-36", studentsFor6);

            return new List<Group> { group31, group34, group36 };
        }
    }
}
