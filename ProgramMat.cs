using System;

internal class RectangleCalculatorV2
{
    static void Main()
    {
        Console.Write("Введите длину прямоугольника: ");
        double length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника: ");
        double width = Convert.ToDouble(Console.ReadLine());
        
        double perimeter = 2 * (length + width);

        double area = length * width;

        double diagonal = Math.Sqrt(length * length + width * width);

        Console.WriteLine($"Периметр: {perimeter}");
        Console.WriteLine($"Площадь: {area}");
        Console.WriteLine($"Диагональ: {diagonal}");
    }
}
