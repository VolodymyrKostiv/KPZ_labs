using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class LabManager
    {
        private const int sizeOfArray = 1_000_000;
        private const int minRandom = 1;
        private const int maxRandom = 50;

        public int NumOfThreads { get; set; } = 1;

        private int[] array;
        private List<int[]> partsOfArray;

        private Stopwatch stopwatch;

        private Dictionary<string, TimeSpan> TimeSpans { get; set; }

        public LabManager()
        {
            CreateArray();
            partsOfArray = SliceArray();
            TimeSpans = new Dictionary<string, TimeSpan>();
            stopwatch = new Stopwatch();
        }

        private void CreateArray()
        {
            array = new int[sizeOfArray];
            Random rand = new Random();

            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = (byte)rand.Next(minRandom, maxRandom);
            }
        }

        public async Task CalculateUsingTask()
        {
            string methodName = $"Task \t\t\t\t-\t {NumOfThreads}\t";
            stopwatch.Start();

            var tasks = new List<Task<int>>(NumOfThreads);
            tasks.AddRange(partsOfArray.Select(arrayPart => Task.Run(arrayPart.Sum)));

            int sum = (await Task.WhenAll(tasks)).Sum();

            double arithmeticMean = (double)sum / array.Length;

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingPLINQ()
        {
            string methodName = $"PLINQ \t\t\t\t-\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = array.AsParallel().WithDegreeOfParallelism(NumOfThreads).Sum();

            int numOfElements = array.AsParallel().WithDegreeOfParallelism(NumOfThreads).Count();
            double arithmeticMean = (double)sum / numOfElements;

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingPLINQWithArraySlicing()
        {
            string methodName = $"PLINQ with array slicing \t-\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = partsOfArray
                        .AsParallel()
                        .WithDegreeOfParallelism(NumOfThreads)
                        .Select(x => x.Sum())
                        .Sum();

            int numOfElements = partsOfArray
                                    .AsParallel()
                                    .WithDegreeOfParallelism(NumOfThreads)
                                    .Select(x => x.Count())
                                    .Sum();
            double arithmeticMean = (double)sum / numOfElements;

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingParallel()
        {
            string methodName = $"Parallel \t\t\t-\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = 0;
            Parallel.For(0, sizeOfArray, i => { sum += array[i]; });

            int numOfElements = 0;
            Parallel.ForEach(array, x => 
            { 
                numOfElements++; 
            });
            double arithmeticMean = (double)sum / numOfElements;

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingParallelWithArraySlicing()
        {
            string methodName = $"Parallel with array slicing \t-\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = 0;
            Parallel.ForEach(partsOfArray, partOfArray => 
            { 
                sum += partOfArray.Sum(); 
            });

            int numOfElements = 0;
            Parallel.ForEach(partsOfArray, partsOfArray => 
            {
                int count = 0;
                for (int i = 0; i < partsOfArray.Length; ++i)
                {
                    ++count;
                }
                numOfElements += count;
            });
            double arithmeticMean = (double)sum / numOfElements;

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingThreadPool()
        {
            string methodName = $"Thread Pool \t\t\t-\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = 0;
            int numOfElements = 0;
            double arithmeticMean = 0;

            using ManualResetEvent resetEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(x =>
                {
                    sum = array.Sum();

                    numOfElements = array.Count();

                    arithmeticMean = (double)sum / numOfElements;

                    resetEvent.Set();

                }));
            resetEvent.WaitOne();

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        public void CalculateUsingThreadPoolWithArraySlicing()
        {
            string methodName = $"Thread Pool with array slicing -\t {NumOfThreads}\t";
            stopwatch.Start();

            int sum = 0;
            int numOfElements = 0;
            double arithmeticMean = 0;

            foreach (int[] x in partsOfArray)
            {
                x.ToList();
                using ManualResetEvent resetEvent = new ManualResetEvent(false);

                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(y =>
                    {
                        sum = x.Sum();

                        numOfElements = x.Count();

                        arithmeticMean = (double)sum / numOfElements;

                        resetEvent.Set();
                    }));
                resetEvent.WaitOne();
            }

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            PrintResultsOfCalculating(methodName, sum, arithmeticMean, 0, elapsed);

            TimeSpans.Add(methodName, elapsed);
        }

        private void PrintResultsOfCalculating(string method, int sum, double arithmeticMean, int moda, TimeSpan time)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Using method - {method}");
            Console.WriteLine($"Number of fixed threads - {NumOfThreads}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Arithmetic mean = {arithmeticMean}");
            Console.WriteLine($"Moda = {moda}");
            Console.WriteLine($"Time = {time}");
            Console.WriteLine("--------------------------------");
        }

        public void PrintArray()
        {
            for (int i = 0; i < sizeOfArray; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        public void PrintTimeSpans()
        {
            TimeSpans.AsEnumerable()
                        .ToList()
                        .ForEach(timeSpan =>
                        {
                            Console.WriteLine($"{timeSpan}");
                        });
        }

        public int GetMostFrequentElement(int[] array)
        {
            return array.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;
        }

        private List<int[]> SliceArray()
        {
            int arraySizePart = (array.Length / NumOfThreads);
            if (array.Length % 2 == 1)
            {
                arraySizePart += 1;
            }

            List<int[]> arrayParts = new List<int[]>(NumOfThreads);

            for (int i = 0; i < array.Length; i += arraySizePart)
            {
                arrayParts.Add(array[i..(
                    arraySizePart + i > array.Length
                        ? array.Length
                        : arraySizePart + i)]);
            }

            return arrayParts;
        }
    }
}
