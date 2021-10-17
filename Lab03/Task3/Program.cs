using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static int numberOfElements = 5_000;
        private static int minRandom = 0;
        private static int maxRandom = 32_767;

        private static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.Write("File path: ");
            string path = Console.ReadLine();
            bool pewdsSongStarted = false;

            while (path != "" && !pewdsSongStarted)
            {
                if (path == "PewDiePie")
                {
                    _ = WritePewdsSongAsync();
                    break;
                }
                else if (!File.Exists(path) && path != " ")
                {
                    _ = WriteNumbersIntoFileAsync(path);
                }
                else
                {
                    Console.WriteLine("Wrong file path or file already exists");
                }

                Console.Write("File path: ");
                path = Console.ReadLine();
            }

            Console.ReadLine();
        }
        static async Task WriteNumbersIntoFileAsync(string filePath)
        {
            Console.WriteLine($"Started writing into {filePath}");

            string resultTime = await Task.Run(() => WriteNumbersIntoFile(filePath));

            Console.WriteLine($"{filePath} finished in {resultTime} using thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static string WriteNumbersIntoFile(string filePath)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (StreamWriter sw = File.CreateText(filePath))
            {
                for (int i = 0; i < numberOfElements; i++)
                {
                    Thread.Sleep(5);
                    int numberToWrite = rand.Next(minRandom, maxRandom);
                    sw.WriteLine($"{i} - {numberToWrite}");
                }
            }

            stopWatch.Stop();
            return stopWatch.Elapsed.ToString();
        }

        static async Task WritePewdsSongAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Started writing pewd's song\n");

                for (int i = 0; i < pewdsSong.Length; ++i)
                {
                    Console.Write(pewdsSong[i]);
                    Thread.Sleep(100);
                }

                Console.WriteLine("\nFinished writing pewd's song");
            });
        }

        #region

        private static string pewdsSong = "\nT-Series! (Yeah!)\n" +
        "A congratulations(woo!), it's a celebration\n" +
        "I just wanna tell you that I think that you're amazing\n" +
        "A congratulations to your corporation\n" +
        "Guess to beat one Swedish boy, you need a billion Asians\n" +
        "Yeah, you did it very nice, and all it took\n" +
        "Was a massive corporate entity with every song in Bollywood\n" +
        "Now you're at number one, hope you did nothing wrong\n" +
        "Like starting your business by selling pirated songs\n" +
        "Oops! Didn't think we'd see? It's right there on Wikipedia\n" +
        "Get used to your past being held against you by the media(uh oh)\n" +
        "I'm sure right now there's nothing that you're doing that's illegal, yeah\n" +
        "I'm certain that you haven't had collusions with the mafia\n" +
        "For legal reasons, that's a joke\n" +
        "For legal reasons, that's a joke\n" +
        "For serious, Indian mafia, please don't kill me, that's a joke\n" +
        "India, I'm sorry 'bout the memes, you're the best\n" +
        "I love my Indian Bros, from Bombay to Bangladesh\n" +
        "I'll take on all the world for you, I'm a heavy hitter\n" +
        "'Bout to cause a genocide so you can call me Hi—\n" +
        "A congratulations, it's a celebration (oh!)\n";

        #endregion
    }
}
