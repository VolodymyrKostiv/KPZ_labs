using System;
using System.Collections.Generic;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> valuesForThreadNum = new List<int>() { 1, 2, 4, 10 };

            LabManager lab = new LabManager();

            //lab.PrintArray();

            lab.CalculateUsingPLINQ();
            lab.CalculateUsingParallel();
            lab.CalculateUsingThreadPool();

            foreach (int num in valuesForThreadNum)
            {
                lab.NumOfThreads = num;

                lab.CalculateUsingPLINQWithArraySlicing();
                lab.CalculateUsingParallelWithArraySlicing();
                lab.CalculateUsingThreadPoolWithArraySlicing();
                lab.CalculateUsingTask();
                Thread.Sleep(5);
            }

            lab.PrintTimeSpans();
        }
    }
}
