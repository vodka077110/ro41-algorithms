using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Строки из задания
string[] inputs = { "", "   ", " a  b ", "А роза упала на лапу Азора", "Ахметов Ерлан" };

// Ожидаемые значения для каждой строки (в том же порядке)
int[] expWords = { 0, 0, 2, 6, 2 };
bool[] expPal = { true, true, false, true, false };
string[] expInitials = { "", "", "A. B.", "А. Р. У. Н. Л. А.", "А. Е." };
string[] expRepeat = { "", "      ", " a  b  a  b ", "А роза упала на лапу АзораА роза упала на лапу Азора", "Ахметов ЕрланАхметов Ерлан" };

int ok = 0, total = 0;

Console.WriteLine("== CountWords ==");
for (int i = 0; i < inputs.Length; i++)
    Check($"CountWords({Q(inputs[i])})", expWords[i].ToString(), TextTools.CountWords(inputs[i]).ToString());

Console.WriteLine("== IsPalindrome ==");
for (int i = 0; i < inputs.Length; i++)
    Check($"IsPalindrome({Q(inputs[i])})", expPal[i].ToString(), TextTools.IsPalindrome(inputs[i]).ToString());

Console.WriteLine("== Initials ==");
for (int i = 0; i < inputs.Length; i++)
    Check($"Initials({Q(inputs[i])})", Q(expInitials[i]), Q(TextTools.Initials(inputs[i])));
Check($"Initials({Q("Ахметов Ерлан Серикұлы")})", Q("А. Е. С."), Q(TextTools.Initials("Ахметов Ерлан Серикұлы")));

Console.WriteLine("== Repeat (n = 2) ==");
for (int i = 0; i < inputs.Length; i++)
    Check($"Repeat({Q(inputs[i])}, 2)", Q(expRepeat[i]), Q(TextTools.Repeat(inputs[i], 2)));
Check("Repeat(\"ab\", 3)", Q("ababab"), Q(TextTools.Repeat("ab", 3)));
Check("Repeat(\"ab\", 0)", Q(""), Q(TextTools.Repeat("ab", 0)));

Console.WriteLine();
Console.WriteLine($"Итого: {ok} из {total} OK");

// Печатает строку: вход | ожидается | получено | OK/FAIL
void Check(string call, string expected, string actual)
{
    total++;
    bool pass = expected == actual;
    if (pass) ok++;
    Console.WriteLine($"  {call} | ожидается: {expected} | получено: {actual} | {(pass ? "OK" : "FAIL")}");
}

// Берёт строку в кавычки, чтобы были видны пробелы
static string Q(string s) => "\"" + s + "\"";


static class TextTools
{
    // Количество слов. Слова разделены пробелами; лишние пробелы
    // (в начале, в конце, несколько подряд) не дают пустых «слов».
    public static int CountWords(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;
        return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    // Палиндром без учёта регистра и пробелов.
    // Два указателя идут навстречу друг другу и пропускают пробелы.
    public static bool IsPalindrome(string s)
    {
        if (s == null)
            return false;

        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (s[left] == ' ') { left++; continue; }
            if (s[right] == ' ') { right--; continue; }

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }
        // Пустая строка и строка из пробелов читаются одинаково в обе стороны
        return true;
    }

    // Инициалы: первая буква каждого слова + точка, через пробел.
    // "Ахметов Ерлан Серикұлы" -> "А. Е. С."
    public static string Initials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return "";

        string[] words = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            if (i > 0)
                sb.Append(' ');
            sb.Append(char.ToUpper(words[i][0]));
            sb.Append('.');
        }
        return sb.ToString();
    }

    // Повторяет строку n раз. Строится через StringBuilder,
    // чтобы не создавать новую строку на каждом шаге.
    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
            return "";

        var sb = new StringBuilder(s.Length * n);
        for (int i = 0; i < n; i++)
            sb.Append(s);
        return sb.ToString();
    }
}
