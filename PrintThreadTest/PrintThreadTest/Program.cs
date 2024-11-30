namespace PrintThreadTest
{
    internal class Program
    {

        static bool printDone = false;
        static object locker = new object { };

        static void Main(string[] args)
        {
            Thread thread = new Thread(Print);
            thread.Start();

            Print();
        }


        private static void Print()
        {
            lock (locker)
            {
                if (!printDone)
                {
                    Console.WriteLine("Hello, World!");
                    printDone = true;
                }
            }
        }
    }
}
