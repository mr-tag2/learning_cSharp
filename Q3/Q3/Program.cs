using System;
using System.Runtime.CompilerServices;

namespace Q3
{
    internal class Program
    {

        static Thread[] threads = new Thread[4];
        static object locker = new object { };
        static bool stop = false;
        static int index = 0;
        static string[] arrayWord = [
            "young",
            "lion",
            "are",
            "fast"
            ];

        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                threads[j] = new Thread(() =>
                {
                    while (!stop)
                    {
                        if (!stop && j == index)
                            PrintWord(j);
                    }
                });
                threads[j].Name = "TH" + j;
                threads[j].Start();
            }
        }


        private static void PrintWord(int i)
        {
            lock (locker)
            {
                if (!stop)
                {

                    Console.WriteLine("T : {0} , Word : {1}", Thread.CurrentThread.Name, arrayWord[i]);

                    if (i == 3)
                        stop = true;
                    else
                        index = index + 1;

                }
            }
        }
    }

}
