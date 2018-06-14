using System;

namespace EulerLibrary2
{
    class Tools
    {
        public static bool IsPrimeNumber(int number)
        {
            var isPrimeNumber = true;
            if (number <= 1)
            {
                isPrimeNumber = false; // because definition
            }

            var x = (int)Math.Sqrt(number);
            for (var i = 2; i <= x; i++)
            {
                if (number % i == 0)
                {
                    isPrimeNumber = false;
                }
            }

            return isPrimeNumber;
        }


        public static bool IsNotPrimeNumber(int value)
        {
            return true;
        }
    }
}
