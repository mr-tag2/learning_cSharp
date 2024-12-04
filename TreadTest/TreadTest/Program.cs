using System;
using System.Threading;
using System.Threading.Tasks;


namespace TreadTest
{
    internal class Program
    {
        //delegate void Test(int x);
        //delegate void Test1();
        //delegate void Test2(object x);

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Test k = func;

            //xx(5);
            //k(6);


            Thread w = new Thread(writeX);
            w.Start();


            //writeX();
            writeY();

        }

        //static void func(int r)
        //{

        //}

        static void writeX()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("-");
            }
        }
        static void writeY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("+");
            }
        }
    }
}
