using System;

namespace DigitsCountAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод s
            Console.Write("Введите целое число n: ");
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

            // sum = 0; count = 0
            long sum = 0;
            int count = 0;

            // Цикл с постусловием: тело выполняется хотя бы один раз,
            // поэтому у числа 0 получается одна цифра
            do
            {
                // sum = sum + n mod 10; count = count + 1; n = n div 10
                sum = sum + n % 10;
                count = count + 1;
                n = n / 10;
            }
            while (n > 0); // n > 0 ?

            // Вывод count, sum
            Console.WriteLine($"Количество цифр: {count}");
            Console.WriteLine($"Сумма цифр: {sum}");
        }
    }
}
