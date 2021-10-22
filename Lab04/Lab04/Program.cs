using System;
using System.Diagnostics;
using System.Linq;

namespace Lab04
{
    class Program
    {
        const int numOfInsideLoops = 10_000_000;
        const int numOfOutsideLoops = 100;
        static void Main(string[] args)
        {
            Dish dish = new Dish("Test", "We", 1, 100, "KPZ", 2021, 0.5);
            
            DishesPriceCalculator dishesPriceCalculator = new DishesPriceCalculator(dish, numOfInsideLoops);
            DishesPriceCalculatorStatic.NumOfLoops = numOfInsideLoops;
            DishesPriceCalculatorStatic.Dish = dish;

            Stopwatch stopwatchForFuncCall = new Stopwatch();
            Stopwatch stopwatchForAllFunc = new Stopwatch();

            TimeSpan totalFuncAccessNonStatic = new TimeSpan(), 
                     totalVarAccessNonStatic = new TimeSpan(), 
                     totalFuncExecutionNonStatic = new TimeSpan();

            for(int i = 0; i < numOfOutsideLoops; i++)
            {
                stopwatchForAllFunc.Reset();
                stopwatchForFuncCall.Reset();

                stopwatchForAllFunc.Start();
                stopwatchForFuncCall.Start();

                (TimeSpan, TimeSpan) resultOfNonStatic = dishesPriceCalculator.CalculateSum(stopwatchForFuncCall);

                stopwatchForAllFunc.Stop();

                totalFuncAccessNonStatic += resultOfNonStatic.Item1;
                totalVarAccessNonStatic += resultOfNonStatic.Item2;
                totalFuncExecutionNonStatic += stopwatchForAllFunc.Elapsed;
            }

            Console.WriteLine($"Total time of calling = {totalFuncAccessNonStatic}");
            Console.WriteLine($"Total time of executing = {totalFuncExecutionNonStatic}");
            Console.WriteLine($"Total time of var access = {totalVarAccessNonStatic}");
            Console.WriteLine();
            Console.WriteLine($"Avg time of calling = {totalFuncAccessNonStatic / numOfOutsideLoops}");
            Console.WriteLine($"Avg time of executing = {totalFuncExecutionNonStatic / numOfOutsideLoops}");
            Console.WriteLine($"Avg time of var access = {totalVarAccessNonStatic / numOfOutsideLoops}");
            Console.WriteLine();

            TimeSpan totalFuncAccessStatic = new TimeSpan(), 
                     totalVarAccessStatic = new TimeSpan(), 
                     totalFuncExecutionStatic = new TimeSpan();

            for (int i = 0; i < numOfOutsideLoops; i++)
            {
                stopwatchForAllFunc.Reset();
                stopwatchForFuncCall.Reset();

                stopwatchForAllFunc.Start();
                stopwatchForFuncCall.Start();

                (TimeSpan, TimeSpan) resultOfStatic = DishesPriceCalculatorStatic.CalculateSum(stopwatchForFuncCall);
                
                stopwatchForAllFunc.Stop();

                totalFuncAccessStatic += resultOfStatic.Item1;
                totalVarAccessStatic += resultOfStatic.Item2;
                totalFuncExecutionStatic += stopwatchForAllFunc.Elapsed;
            }

            Console.WriteLine($"Total time of calling = {totalFuncAccessStatic}");
            Console.WriteLine($"Total time of executing = {totalFuncExecutionStatic}");
            Console.WriteLine($"Total time of var access = {totalVarAccessStatic}");
            Console.WriteLine();
            Console.WriteLine($"Avg time of calling = {totalFuncAccessStatic / numOfOutsideLoops}");
            Console.WriteLine($"Avg time of executing = {totalFuncExecutionStatic / numOfOutsideLoops}");
            Console.WriteLine($"Avg time of var access = {totalVarAccessStatic / numOfOutsideLoops}");
            Console.WriteLine();

            Console.ReadLine();

            #region some method calls
            //TryDishAccess(dish);
            //BoxingUnboxingPrice(dish.price);
            //Convert(dish);

            //Dish dish1 = "Dish?";
            //string res = (string) dish1;

            //Name name = new Name("First", "Second", "Father");
            //ItalianChef chef = new ItalianChef(name, ChefTypes.CHIEF_COOKER);
            //chef.MixChefs();
            //BoxingUnboxingPrice(dish.price);
            //IncreaseDish(dish);
            #endregion
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
