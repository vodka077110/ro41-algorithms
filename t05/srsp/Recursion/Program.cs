using System;

// Проверка DigitSum
TestDigitSum(0);
TestDigitSum(7);
TestDigitSum(12345);
TestDigitSum(1000);

// Проверка Pow
TestPow(2, 0);
TestPow(2, 10);
TestPow(5, 3);
TestPow(7, 1);

// Выводит строку вида «DigitSum(12345) = 15».
static void TestDigitSum(int n)
{
    Console.WriteLine($"DigitSum({n}) = {Rec.DigitSum(n)}");
}

// Выводит строку вида «Pow(2, 10) = 1024».
static void TestPow(int x, int n)
{
    Console.WriteLine($"Pow({x}, {n}) = {Rec.Pow(x, n)}");
}


static class Rec
{
    // Сумма цифр неотрицательного числа n.
    // Идея: последняя цифра (n % 10) + сумма цифр числа без неё (n / 10).
    public static int DigitSum(int n)
    {
        // Базовый случай: однозначное число (0..9) — сумма цифр равна самому числу
        if (n < 10)
            return n;

        // Шаг рекурсии: отрезаем последнюю цифру и считаем сумму остальных
        return n % 10 + DigitSum(n / 10);
    }

    // x в степени n (n >= 0) без Math.Pow.
    // Идея: x^n = x * x^(n-1).
    public static long Pow(int x, int n)
    {
        // Базовый случай: любое число в степени 0 равно 1
        if (n == 0)
            return 1;

        // Шаг рекурсии: уменьшаем степень на 1
        return x * Pow(x, n - 1);
    }
}
