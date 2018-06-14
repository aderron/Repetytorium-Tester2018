using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary2
{
    class Tools
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number == 1)
            {
                return false; // because definition
            }

            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
