using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab04
{
    static class DishesPriceCalculatorStatic
    {
        static public Dish Dish { get; set; }
        static public int NumOfLoops { get; set; }

        static public (TimeSpan functionCall, TimeSpan variableCall) CalculateSum(Stopwatch stopwatch)
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
