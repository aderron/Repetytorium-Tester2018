using System;
using System.Linq;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Way of the LINQ
            var result = Enumerable.Range(0, 1000)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Select(i => (long)i)
                .Sum();

            // The understandable way
            long sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                    // sum = sum + i;
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
