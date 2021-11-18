using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab04
{
    


    class Program
    {

        interface A
        {
            void Hello();
        }

        class Test : A 
        {
            void A.Hello()
            {
                Console.WriteLine("Hell");
            }
        }



        static void Main(string[] args)
        {
            A myTest = new Test();
            myTest.Hello();

        }

        #region some weird functions

        static void IncreaseDish(Dish dish)
        {
            ItalianChef chef = new ItalianChef();
            int newPrice = 0;
            Console.WriteLine("--------------------");
            Console.WriteLine($"Dish = {dish.name}");
            chef.IncreasePortion(dish, newPrice);
            Console.WriteLine($"New price = {newPrice}");
            Console.WriteLine($"New dish = {dish.name}");
            chef.IncreasePortion(ref dish, out int newPrice2);
            Console.WriteLine($"New price = {newPrice2}");
            Console.WriteLine($"New dish = {dish.name}");

        }

        static void TryDishAccess(Dish dishToTestAccess)
        {
            Console.WriteLine(dishToTestAccess.name);
            Console.WriteLine(dishToTestAccess.ingredients);
            Console.WriteLine(dishToTestAccess.price);
            //Console.WriteLine(timeToCook);
            //Console.WriteLine(country);
            //Console.WriteLine(yearOfFounding);
        }

        static void BoxingUnboxingPrice(object obj)
        {
            var num = (int)obj;
            Console.WriteLine($"Obj price = {obj}");
            Console.WriteLine($"Int Price = {num}");
        }

        static void Convert(Dish dish)
        {
            string name = (string)dish;
            Console.WriteLine($"Country = {name}");
            Dish newDish = name;
            Console.WriteLine($"Name (country) = {newDish.name}");
        }
        #endregion
    }
}
