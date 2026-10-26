using System;

namespace SecondsToTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод s
            Console.Write("Введите количество секунд: ");
            string? s = Console.ReadLine();

            // s — целое число n?
            long n;
            if (!long.TryParse(s, out n))
            {
                Console.WriteLine("Ошибка: введено не целое число.");
                return;
            }

            // n < 0 ?
            if (n < 0)
            {
                Console.WriteLine("Ошибка: число не может быть отрицательным.");
                return;
            }

            // h = n div 3600; m = (n mod 3600) div 60; sec = n mod 60
            long h = n / 3600;
            long m = n % 3600 / 60;
            long sec = n % 60;

            // Вывод h, m, sec
            Console.WriteLine($"{h} ч {m} мин {sec} сек");
        }
    }
}
