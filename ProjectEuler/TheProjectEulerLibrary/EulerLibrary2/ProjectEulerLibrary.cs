using System;
using System.Linq;

namespace TheProjectEulerLibrary
{
    public class ProjectEulerLibrary
    {
        public static long ClassicMultiplesOf3And5(int limit)
        {
            long sum = 0;
            for (int i = 1; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i; // sum = sum + i;
                }
            }

            return sum;
        }

        public static long LinqMultiplesOf3And5(int limit)
        {
            var result = Enumerable.Range(0, limit)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();
            return result;
        }
    }
}
