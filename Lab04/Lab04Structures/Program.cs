using System;
using System.Linq;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish dish = new Dish("This is only test dish", "We don't need them", 10, 100, "KPZ", 2021, 0.5) { price = 30 };

            //TryDishAccess(dish);
            //BoxingUnboxingPrice(dish.price);
            //Convert(dish);
            //Name name = new Name("First", "Second", "Father");
            //ItalianChef chef = new ItalianChef(name, ChefTypes.CHIEF_COOKER);
            //chef.MixChefs();
            //BoxingUnboxingPrice(dish.price);
            //IncreaseDish(dish);
        }
    }
}
