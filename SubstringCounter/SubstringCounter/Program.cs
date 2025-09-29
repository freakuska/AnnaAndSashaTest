using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите первую строку:");
            string str1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку:");
            string str2 = Console.ReadLine();

            if (string.IsNullOrEmpty(str2))
            {
                Console.WriteLine("Ошибка: Вторая строка не может быть пустой.");
                return;
            }

            int count = CountOccurrences(str1, str2);
            Console.WriteLine($"Количество вхождений второй строки в первую: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static int CountOccurrences(string str1, string str2)
    {
        int count = 0;
        int index = 0;

        while ((index = str1.IndexOf(str2, index)) != -1)
        {
            count++;
            index += str2.Length;
        }

        return count;
    }
}