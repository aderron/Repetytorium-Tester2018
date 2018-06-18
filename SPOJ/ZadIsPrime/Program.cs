using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadIsPrime
{
    class Program
    {
        static String IsPrime(int a)
        {
            for(int i=2; i<a; i++)
            {
                if(a % i == 0)
                {
                    return "NIE";
                }
            }
            return "TAK";
        }
        static void Main(string[] args)
        {
            int a = 7;
            String wynik = IsPrime(a);
            Console.WriteLine("'a' jest liczba pierwsza? -" + wynik);
            Console.ReadKey();
        }
    }
}
