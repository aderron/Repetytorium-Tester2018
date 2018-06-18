using System;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            var dzielna = 600851475143;
            var dzielnik = 2;
            long najDzielnik = 0;
            bool znaleziono = false;


            while (znaleziono == false)
            {
                while (dzielna % dzielnik != 0)
                {
                    dzielnik++;
                }
                najDzielnik = dzielna / dzielnik;
                Console.WriteLine("Aktualny najwiekszy dzielnik: " + najDzielnik);

                for (var i = 2; i < najDzielnik; i++)
                {
                    if (najDzielnik % i == 0)
                    {
                        Console.WriteLine("Aktualny najwiekszy dzielnik nie jest liczba pierwsza, bo dzieli sie przez: " + i);
                        dzielnik++;
                        break;
                    }
                    else if (i == najDzielnik - 1)
                    {
                        znaleziono = true;
                    }
                }
            }
            Console.WriteLine(najDzielnik + " to najwiekszy dzielnik bedacy liczba pierwsza.");
            Console.ReadKey();
        }
    }
}
