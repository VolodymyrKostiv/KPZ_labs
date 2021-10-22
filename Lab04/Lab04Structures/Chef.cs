using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    enum ChefTypes 
    {
        CHIEF_COOKER = 1,
        SOUS_CHEF = 10,
        SENIOR_CHEF = 100,
    }
    struct Name
    {
        string firstName;
        internal string lastName;
        public string fatherName;

        public Name(string firstName, string lastName, string fatherName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fatherName = fatherName;
        }
    }
    struct Chef : IChef
    {
        Name name;
        ChefTypes type;
        static int numberOfChefs;
        
        public Chef(Name name, ChefTypes type)
        {
            this.name = name;
            this.type = type;
        }

        public Dish Cook()
        {
            Dish dish = new Dish("This is only test dish", "We don't need them", 10, 100, "KPZ", 2021, 0.5);
            return dish;
        }

        public void MixChefs()
        {
            Console.WriteLine($"Chief Cooker = {ChefTypes.CHIEF_COOKER}," +
                              $"Senior Chef = {ChefTypes.SENIOR_CHEF}, " +
                              $"Sous chef = {ChefTypes.SOUS_CHEF}");

            Console.WriteLine($"Chief Cooker | Senior Chef = {ChefTypes.CHIEF_COOKER | ChefTypes.SENIOR_CHEF}");
            Console.WriteLine($"Senior Chef & Sous Chef = {ChefTypes.SENIOR_CHEF & ChefTypes.SOUS_CHEF}");
            Console.WriteLine($"Chief Cooker ^ Senior Chef = {ChefTypes.CHIEF_COOKER ^ ChefTypes.SENIOR_CHEF}");
            //Console.WriteLine($"Chief Cooker && Senior Chef = {ChefTypes.CHIEF_COOKER && ChefTypes.SENIOR_CHEF}");
            //Console.WriteLine($"Chief Cooker || Senior Chef = {ChefTypes.CHIEF_COOKER || ChefTypes.SENIOR_CHEF}");
        }
    }
}
