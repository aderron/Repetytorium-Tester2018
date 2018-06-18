using System;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {

            var fibA = 1;
            var fibB = 2;
            long sum = 0;


            while (fibB < 4000000)
            {
                if (fibB % 2 == 0)
                {
                    sum += fibB;
                }

                var oldA = fibA;
                fibA = fibB;
                fibB = oldA + fibA;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
