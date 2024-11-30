using System;
using System.Runtime.CompilerServices;

namespace DiceRandom
{
    internal class Program
    {

        static Thread[] threads = new Thread[5];
        static object locker = new object { };
        static bool stop = false;
        static int index = 0;


        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                int j = i;
                threads[j] = new Thread(() =>
                {
                    while (!stop)
                    {
                        if (!stop && j == index)
                            RandomCall();
                    }
                });
                threads[j].Name = "T" + j;
                threads[j].Start();
            }
        }


        private static void RandomCall()
        {
            lock (locker)
            {
                if (!stop)
                {
                    Random random = new Random();

                    int d1 = random.Next(0, 6) + 1;
                    int d2 = random.Next(0, 6) + 1;

                    if (d1 == 6 && d2 == 6)
                    {
                        //Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("T : {0} , D1 : {1}, D2 : {2}", Thread.CurrentThread.Name, d1, d2);
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("T : {0} , D1 : {1}, D2 : {2}", Thread.CurrentThread.Name, d1, d2);
                        index = index >= 4 ? 0 : index + 1;
                    }
                }
            }
        }
    }

}
