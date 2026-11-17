using System;

// Проверка на массивах из задания
Test(new int[] { 4, 1, 7, 3, 9 });
Test(new int[] { 5 });
Test(new int[] { -2, -7, -4 });
Test(new int[] { 2, 2, 2 });

// Выводит исходный массив, сумму, индекс минимума, CountGreater при x = 2 и массив после Reverse.
static void Test(int[] a)
{
    Console.WriteLine($"Массив: {Show(a)}");
    Console.WriteLine($"  Sum = {ArrayOps.Sum(a)}");
    Console.WriteLine($"  IndexOfMin = {ArrayOps.IndexOfMin(a)}");
    Console.WriteLine($"  CountGreater(x = 2) = {ArrayOps.CountGreater(a, 2)}");
    ArrayOps.Reverse(a);
    Console.WriteLine($"  После Reverse: {Show(a)}");
    Console.WriteLine();
}

// Превращает массив в строку вида «{4, 1, 7, 3, 9}».
static string Show(int[] a)
{
    return "{" + string.Join(", ", a) + "}";
}


static class ArrayOps
{
    // Сумма всех элементов массива.
    public static int Sum(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
            sum += a[i];
        return sum;
    }

    // Индекс первого минимального элемента.
    public static int IndexOfMin(int[] a)
    {
        // Начальное значение минимума берём из массива (а не 0),
        // иначе на массиве из положительных чисел ответ будет неверным.
        int minIndex = 0;
        for (int i = 1; i < a.Length; i++)
        {
            // Строго «<», чтобы при одинаковых минимумах остался ПЕРВЫЙ из них
            if (a[i] < a[minIndex])
                minIndex = i;
        }
        return minIndex;
    }

    // Количество элементов, которые строго больше x.
    public static int CountGreater(int[] a, int x)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > x)
                count++;
        }
        return count;
    }

    // Разворачивает массив на месте: меняет местами a[i] и a[n - 1 - i].
    // Цикл идёт только до середины (n / 2), иначе пары поменяются обратно.
    public static void Reverse(int[] a)
    {
        int n = a.Length;
        for (int i = 0; i < n / 2; i++)
        {
            int t = a[i];
            a[i] = a[n - 1 - i];
            a[n - 1 - i] = t;
        }
    }
}
