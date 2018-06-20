using System;

namespace Przedszkolanka
{
    // Solution for https://pl.spoj.com/problems/PRZEDSZK/
    class Program
    {
        static void Main(string[] args)
        {
            var solutionCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < solutionCount; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var a = int.Parse(input[0]);
                var b = int.Parse(input[1]);

                var c = SCD(a, b);
                Console.WriteLine(c);
            }
        }

        public static int SCD(int a, int b)
        {
            for (var i = a; i < 1000000; i ++)
            {
                if (i % a == 0 && i % b == 0)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
