using System;

namespace ZadFCTRL3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe: ");
            var liczba = uint.Parse(Console.ReadLine());
            long wynik = 1;

            for(int i=1; i<=liczba; i++)
            {
                wynik = wynik * i;
            }

            long jednosci = wynik % 10;
            long dziesiatki = (wynik % 100) / 10;
            Console.WriteLine("jednosci: " + jednosci);
            Console.WriteLine("dziesiatki: " + dziesiatki);
            Console.ReadKey();     
        }
    }
}
