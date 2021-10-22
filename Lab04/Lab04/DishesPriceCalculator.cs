using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class DishesPriceCalculator
    {
        public Dish Dish { get; set; }
        public int NumOfLoops { get; set; }

        public DishesPriceCalculator()
        {
        }

        public DishesPriceCalculator(Dish dish, int numOfLoops)
        {
            Dish = dish;
            NumOfLoops = numOfLoops;
        }
        
       public (TimeSpan functionCall, TimeSpan variableCall) CalculateSum(Stopwatch stopwatch)
       {
            stopwatch.Stop();
            TimeSpan funcCallTime = stopwatch.Elapsed;
            stopwatch.Reset();
            stopwatch.Start();

            int sum = 0;
            TimeSpan totalAccessToVariables = new TimeSpan(); 
            for (int i = 0; i < NumOfLoops; i++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                sum += Dish.price;
                stopwatch.Stop();
                totalAccessToVariables += stopwatch.Elapsed;
            }

            return (funcCallTime, totalAccessToVariables / NumOfLoops);
        }

    }
}
