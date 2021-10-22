using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class ForbiddenRecipe : Dish
    {
        public ForbiddenRecipe(string name, string ingredients, int price, int timeToCook, 
                               string country, int yearOfFounding, double weight) 
            : base(name, ingredients, price, timeToCook, country, yearOfFounding, weight) 
        {
        }

        public void TryFatherAccess()
        {
            Console.WriteLine(name);
            Console.WriteLine(ingredients);
            Console.WriteLine(price);
            Console.WriteLine(timeToCook);
            Console.WriteLine(country);
            //Console.WriteLine(yearOfFounding);
        }
    }
}
