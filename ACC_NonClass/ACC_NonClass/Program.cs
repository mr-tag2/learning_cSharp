using System;
using System.Collections.Generic;

namespace AccountingAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string?[]> transactions = new List<string?[]>();
            while (true)
            {
                Console.WriteLine("Welcome!\n-------------------------------------------\n");
                Console.WriteLine("1 - Add Transaction ");
                Console.WriteLine("2 - Show All ");
                Console.WriteLine("3 - Exit ");
                Console.Write("Enter Your Choice: ");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 3) break;
                    else if (choice == 1)
                    {
                        Console.WriteLine("\n\nEnter Your Transaction Values.\n\n");

                        Console.Write("Enter Value: ");
                        string? value = Console.ReadLine();

                        Console.Write("Enter Title: ");
                        string? title = Console.ReadLine();

                        Console.Write("Enter Description: ");
                        string? description = Console.ReadLine();

                        transactions.Add(new string?[] { title, value, description });
                    }
                    else if (choice == 2)
                    {
                        Console.Write("\nTitle\t\tValue\t\tDescription\n-------------------------------------------");

                        for (int i = 0; i < transactions.Count; i++)
                        {
                            string?[] transaction = transactions[i];

                            Console.Write("\n"+ transaction[0] + "\t\t" + transaction[1] + "\t\t" + transaction[2] + "\n");
                        }

                        Console.Write("\nPress Enter To Confirm   ");
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("\n-------------------------------------------\nError\n-------------------------------------------\n");
                }
            }
        }
    }
}
