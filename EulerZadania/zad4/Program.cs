using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    class Program
    {
        static void Main(string[] args)
        {
            int iloczyn;
            int max = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    iloczyn = i * j;
                    if (isPalindrome(iloczyn))
                    {
                        max = Math.Max(max, iloczyn);
                    }
                }
            }
            Console.WriteLine("Najwiekszy palindrom to: " + max);
            Console.ReadKey();
        }

        private static bool isPalindrome(int iloczyn)
        {
            String iloczynStr = iloczyn.ToString();
            String lewaPolowa;
            String prawaPolowa;
            String odwroconaPrawaPolowa;
            int polowaDlugosci = iloczynStr.Length / 2;
            lewaPolowa = iloczynStr.Substring(0, polowaDlugosci);
            prawaPolowa = iloczynStr.Substring((iloczynStr.Length - polowaDlugosci), polowaDlugosci);
            odwroconaPrawaPolowa = Reverse(prawaPolowa);
            
            if(lewaPolowa.Equals(odwroconaPrawaPolowa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}
