using System;

namespace Cwiczenie_01_Indeksy_i_Zakresy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenie 1\n");

            string[] slowa = new string[]
            {
            // Indeks               od początku     od końca
            "Już północ",           // 0            ^10
            "cień",                 // 1            ^9
            "ponury",               // 2            ^8
            "pół",                  // 3            ^7
            "świata",               // 4            ^6
            "okrywa",               // 5            ^5
            "A jeszcze",            // 6            ^4
            "serce",                // 7            ^3
            "zmysłom",              // 8            ^2
            "spoczynku nie daje"    // 9            ^1
                                    // 10(słowa.Lenght) ^0

            };

            // =================================================================
            Console.WriteLine("Pkt. 1\n");
            Console.WriteLine($"{slowa[^1]}");

            // =================================================================
            Console.WriteLine("\nPkt. 2\n");
            string[] sonet1 = slowa[2..6];
            foreach (var slowo in sonet1)
                Console.Write($"< { slowo} >");

            Console.WriteLine();

            // =================================================================
            Console.WriteLine("\nPkt. 3\n");
            string[] sonet2 = slowa[^3..^0];
            foreach (var slowo in sonet2)
                Console.Write($"{slowo}");
            Console.WriteLine();

            // =================================================================
            Console.WriteLine("\nPkt. 4\n");
            string[] sonet3 = slowa[..];
            string[] sonet4 = slowa[..5];
            string[] sonet5 = slowa[7..];

            foreach (var slowo in sonet3)
                Console.Write($"{slowo}");
            Console.WriteLine();

            foreach (var slowo in sonet4)
                Console.Write($"{slowo}");
            Console.WriteLine();

            foreach (var slowo in sonet5)
                Console.Write($"{slowo}");
            Console.WriteLine();

            // =================================================================
            Console.WriteLine("\nPkt. 5\n");
            Index stri = ^5;
            Console.WriteLine(slowa[stri]);


            // =================================================================
            Console.WriteLine("\nPkt. 6\n");
            Range fraza = 2..7;
            string[] tekst = slowa[fraza];
            foreach (var slowo in tekst)
                Console.Write($" {slowo} ");
            Console.WriteLine();

        }
    }
}
