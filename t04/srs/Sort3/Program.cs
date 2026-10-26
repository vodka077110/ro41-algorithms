using System;

// Проверка на тройках из задания
Test(3, 1, 2);
Test(1, 2, 3);
Test(3, 2, 1);
Test(2, 2, 1);
Test(5, 5, 5);

// Выводит строку вида «3 1 2 -> 1 2 3».
// a, b, c передаются по значению — это копии, поэтому исходная тройка не теряется.
static void Test(int a, int b, int c)
{
    string before = $"{a} {b} {c}";
    Order.Sort3(ref a, ref b, ref c);
    Console.WriteLine($"{before} -> {a} {b} {c}");
}


static class Order
{
    // Меняет местами значения двух переменных.
    public static void Swap(ref int x, ref int y)
    {
        int t = x;
        x = y;
        y = t;
    }

    // Упорядочивает три числа по возрастанию, используя только Swap.
    public static void Sort3(ref int a, ref int b, ref int c)
    {
        // 1. Наименьшее из a и b — в a
        if (a > b)
            Swap(ref a, ref b);
        // 2. Наименьшее из a и c — в a; теперь a — минимум всех трёх
        if (a > c)
            Swap(ref a, ref c);
        // 3. Из оставшихся b и c меньшее — в b
        if (b > c)
            Swap(ref b, ref c);
    }
}
