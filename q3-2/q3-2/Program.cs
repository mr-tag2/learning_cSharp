using System;
using System.Runtime.CompilerServices;

namespace Q3_2
{
    internal class Program
    {

        static Thread[] threads = new Thread[4];
        static int step = 0;
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
                    while (step < 4)
                        if (step < 4 && j == step)
                        {
                            Console.Write(arrayWord[j]+" ");
                            step++;
                        }

                });
                threads[j].Start();
            }
        }


    }

}
