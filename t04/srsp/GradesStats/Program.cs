using System;

// ===== Инструкции верхнего уровня (схема верхнего уровня) =====

// count = 0; sum = 0; fives = 0
int count = 0;
int sum = 0;
int fives = 0;

// g = Grades.Read()
int g = Grades.Read();

// g ≠ Stop ?
while (g != Grades.Stop)
{
    // ok = Grades.IsValid(g)
    bool ok = Grades.IsValid(g);

    // ok ?
    if (ok)
    {
        // count = count + 1; sum = sum + g
        count = count + 1;
        sum = sum + g;

        // g = Max ?
        if (g == Grades.Max)
        {
            // fives = fives + 1
            fives = fives + 1;
        }
    }

    // g = Grades.Read()
    g = Grades.Read();
}

// Grades.PrintStats(count, sum, fives)
Grades.PrintStats(count, sum, fives);


// ===== Методы =====

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    // Читает оценку. Нечисловой ввод возвращает -1.
    // Если ввод закончился (ReadLine вернул null), возвращает Stop,
    // чтобы программа не зациклилась.
    public static int Read()
    {
        Console.Write($"Оценка ({Stop} — конец): ");
        string? s = Console.ReadLine();
        if (s == null)
            return Stop;
        if (!int.TryParse(s, out int g))
            return -1;
        return g;
    }

    // Оценка от Min до Max включительно.
    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    // Выводит итог или «Оценок нет».
    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
            return;
        }
        double avg = (double)sum / count;
        Console.WriteLine($"Количество оценок: {count}");
        Console.WriteLine($"Средний балл: {avg:F2}");
        Console.WriteLine($"Пятёрок: {fives}");
    }
}
