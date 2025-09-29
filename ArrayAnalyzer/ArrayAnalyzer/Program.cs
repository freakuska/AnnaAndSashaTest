using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите размер массива (N):");
            int N = Convert.ToInt32(Console.ReadLine());

            if (N <= 0)
            {
                Console.WriteLine("Ошибка: Размер массива должен быть положительным числом.");
                return;
            }

            double[] array = new double[N];
            Console.WriteLine("Введите элементы массива:");

            for (int i = 0; i < N; i++)
            {
                Console.Write($"A[{i + 1}] = ");
                array[i] = Convert.ToDouble(Console.ReadLine());
            }

            double maxOdd = double.MinValue;
            int evenCount = 0;

            foreach (double num in array)
            {
                if (num % 2 != 0)
                {
                    if (num > maxOdd)
                    {
                        maxOdd = num;
                    }
                }
                else
                {
                    evenCount++;
                }
            }

            if (maxOdd == double.MinValue)
            {
                Console.WriteLine("Нечетных чисел в массиве нет.");
            }
            else
            {
                Console.WriteLine($"Наибольшее нечетное число: {maxOdd}");
            }

            Console.WriteLine($"Количество четных чисел: {evenCount}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введенные данные не являются числами.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введено слишком большое или маленькое число.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}