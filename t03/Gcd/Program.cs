using System;

namespace Gcd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод a, b
            Console.Write("Введите a: ");
            string? sa = Console.ReadLine();
            Console.Write("Введите b: ");
            string? sb = Console.ReadLine();

            // a и b — целые числа?
            long a, b;
            if (!long.TryParse(sa, out a) || !long.TryParse(sb, out b))
            {
                Console.WriteLine("Ошибка: введено не целое число.");
                return;
            }

            // a < 0 или b < 0 или a = b = 0 ?
            if (a < 0 || b < 0 || (a == 0 && b == 0))
            {
                Console.WriteLine("Ошибка: нужно a ≥ 0, b ≥ 0, и они не могут быть оба равны 0.");
                return;
            }

            // b ≠ 0 ? (цикл с предусловием)
            while (b != 0)
            {
                // r = a mod b; a = b; b = r
                long r = a % b;
                a = b;
                b = r;
            }

            // Вывод a
            Console.WriteLine($"НОД = {a}");
        }
    }
}
