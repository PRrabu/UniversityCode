using System;

internal class RectangleCalculatorV2
{
    static void Main()
    {
        // Запрос длины и ширины прямоугольника
        Console.Write("Введите длину прямоугольника: ");
        double length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника: ");
        double width = Convert.ToDouble(Console.ReadLine());

        // Вычисление периметра
        double perimeter = 2 * (length + width);

        // Вычисление площади
        double area = length * width;

        // Вычисление диагонали
        double diagonal = Math.Sqrt(length * length + width * width);

        // Вывод результатов
        Console.WriteLine($"Периметр: {perimeter}");
        Console.WriteLine($"Площадь: {area}");
        Console.WriteLine($"Диагональ: {diagonal}");
    }
}
