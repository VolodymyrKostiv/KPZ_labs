using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Dish
    {
        public string name;
        internal string ingredients;
        protected internal int price = 10;
        protected int timeToCook;
        private protected string country;
        private int yearOfFounding;
        public double weight = 0.15;

        static int numOfDishes;

        static Dish()
        {
            numOfDishes = 10;
        }

        public Dish(string name) 
        {
            this.name = name;
        }

        public Dish(int timeToCook, string country, int yearOfFounding, double weight, string name) : this(name)
        {
            this.timeToCook = timeToCook;
            this.country = country;
            this.yearOfFounding = yearOfFounding;
            this.weight = weight;
        }

        public Dish(string name, string ingredients, int price, int timeToCook, 
                    string country, int yearOfFounding, double weight) 
            : this(timeToCook, country, yearOfFounding, weight, name)
        {
            this.ingredients = ingredients;
            this.price = price;
        }

        class DefaultInnerClass
        {
            public void TestForInnerClass()
            {
                Console.WriteLine("Hello from inner class");
            }
        }

        public static implicit operator Dish(string name) => new Dish(name);
        public static explicit operator string(Dish dish) => dish.country;

        public class PublicInnerClass { }
        internal class InternalInnerClass { }
        protected internal class ProtectedInternalClass { }
        protected class ProtectedClass { }
        private protected class PrivateProtectedInternalClass { }
        private class PrivateInternalClass { }

    }
}
