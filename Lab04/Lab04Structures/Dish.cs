using System;

namespace Lab04
{
    struct Dish
    {
        public string name;
        internal string ingredients;
        internal int price;
        int timeToCook;
        private string country;
        private int yearOfFounding;
        public double weight;

        static int numOfDishes;

        static Dish()
        {
            numOfDishes = 10;
        }

        public Dish(string name, string ingredients, int price, int timeToCook, 
                    string country, int yearOfFounding, double weight) 
        {
            this.name = name;
            this.ingredients = ingredients;
            this.price = price;
            this.timeToCook = timeToCook;
            this.country = country;
            this.yearOfFounding = yearOfFounding;
            this.weight = weight;
        }

        class DefaultInnerClass
        {
            public void TestForInnerClass()
            {
                Console.WriteLine("Hello from inner class");
            }
        }
    }
}
