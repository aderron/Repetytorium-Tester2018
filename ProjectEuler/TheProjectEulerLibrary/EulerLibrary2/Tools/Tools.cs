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

        public static bool IsPalindrome(int number)
        {
            var charArray = number.ToString().ToCharArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                var isEqual = charArray[i] == charArray[charArray.Length - i - 1];
                if (!isEqual)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
