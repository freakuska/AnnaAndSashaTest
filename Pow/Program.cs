using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите коэффициенты a, b, c для уравнения ax^2 + bx + c = 0:");
            Console.Write("a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c = ");
            double c = Convert.ToDouble(Console.ReadLine());
            string result = SolveQuadraticEquation(a, b, c);
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введенные данные не являются числами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static string SolveQuadraticEquation(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    return "Уравнение неразрешимо: бесконечное множество решений.";
                }
                else
                {
                    return "Уравнение неразрешимо: нет решений.";
                }
            }
            else
            {
                double x = -c / b;
                return $"Неквадратное уравнение: x = {x}";
            }
        }

        double D = b * b - 4 * a * c;

        if (D > 0)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            return $"Два вещественных корня: x₁ = {x1}, x₂ = {x2}";
        }
        else if (D == 0)
        {
            double x = -b / (2 * a);
            return $"Один вещественный корень: x = {x}";
        }
        else
        {
            return "Корни комплексные.";
        }
    }
}