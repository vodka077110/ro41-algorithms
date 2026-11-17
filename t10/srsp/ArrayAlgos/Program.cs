using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// ---- Проверка BubbleSort ----
Console.WriteLine("== BubbleSort ==");
TestBubble(new int[] { });
TestBubble(new int[] { 5 });
TestBubble(new int[] { 1, 2, 3, 4, 5 });
TestBubble(new int[] { 5, 4, 3, 2, 1 });
TestBubble(new int[] { 3, 1, 3, 2, 3 });

// Отсортированный массив из 1000 элементов: ожидается 999 сравнений
int[] big = new int[1000];
for (int i = 0; i < big.Length; i++)
    big[i] = i;
int bigCmp = ArrayAlgos.BubbleSort(big);
Console.WriteLine($"Отсортированный массив из 1000 элементов: сравнений = {bigCmp} (ожидается 999) {(bigCmp == 999 ? "OK" : "FAIL")}");
Console.WriteLine();

// ---- Проверка CountOccurrences ----
Console.WriteLine("== CountOccurrences ==");
int[] sorted = { 1, 2, 2, 2, 5, 7 };
int[] xs = { 2, 1, 7, 3, 9 };
int[] expected = { 3, 1, 1, 0, 0 };
Console.WriteLine($"Массив: {Show(sorted)}");
for (int i = 0; i < xs.Length; i++)
{
    int actual = ArrayAlgos.CountOccurrences(sorted, xs[i]);
    Console.WriteLine($"  x = {xs[i]}: ожидается {expected[i]}, получено {actual} {(actual == expected[i] ? "OK" : "FAIL")}");
}

// Выводит массив до и после сортировки, IsSorted и число сравнений.
static void TestBubble(int[] a)
{
    string before = Show(a);
    bool sortedBefore = ArrayAlgos.IsSorted(a);
    int comparisons = ArrayAlgos.BubbleSort(a);
    Console.WriteLine($"До: {before} (IsSorted = {sortedBefore})");
    Console.WriteLine($"  После: {Show(a)} (IsSorted = {ArrayAlgos.IsSorted(a)})");
    Console.WriteLine($"  Сравнений: {comparisons}");
}

// Превращает массив в строку вида «{1, 2, 3}».
static string Show(int[] a)
{
    return "{" + string.Join(", ", a) + "}";
}


static class ArrayAlgos
{
    // true, если каждый элемент не больше следующего.
    // Пустой массив и массив из одного элемента считаются отсортированными.
    public static bool IsSorted(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1])
                return false;
        }
        return true;
    }

    // Сортировка пузырьком на месте с флажком раннего выхода.
    // Возвращает число сравнений соседних элементов.
    public static int BubbleSort(int[] a)
    {
        int comparisons = 0;
        int n = a.Length;

        for (int pass = 0; pass < n - 1; pass++)
        {
            bool swapped = false;   // флажок: был ли хоть один обмен за проход

            // После каждого прохода самый большой элемент «всплывает» в конец,
            // поэтому последние pass элементов уже не проверяем.
            for (int j = 0; j < n - 1 - pass; j++)
            {
                comparisons++;
                if (a[j] > a[j + 1])
                {
                    int t = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = t;
                    swapped = true;
                }
            }

            // Ранний выход: обменов не было — массив уже отсортирован
            if (!swapped)
                break;
        }
        return comparisons;
    }

    // Количество вхождений x в отсортированном массиве.
    // = (первый индекс элемента > x) − (первый индекс элемента >= x).
    // Два бинарных поиска, без прохода по всему массиву.
    public static int CountOccurrences(int[] sortedA, int x)
    {
        return UpperBound(sortedA, x) - LowerBound(sortedA, x);
    }

    // Первый индекс элемента >= x (если такого нет — a.Length).
    private static int LowerBound(int[] a, int x)
    {
        int lo = 0, hi = a.Length;
        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (a[mid] < x)
                lo = mid + 1;
            else
                hi = mid;
        }
        return lo;
    }

    // Первый индекс элемента > x (если такого нет — a.Length).
    private static int UpperBound(int[] a, int x)
    {
        int lo = 0, hi = a.Length;
        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (a[mid] <= x)
                lo = mid + 1;
            else
                hi = mid;
        }
        return lo;
    }
}
