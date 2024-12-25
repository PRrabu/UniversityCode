using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число n: ");
        int n = int.Parse(Console.ReadLine());

        double sumOfSquareRoots = 0;

        for (int i = 1; i <= n; i++)
        {
            sumOfSquareRoots += Math.Sqrt(i);
        }

        Console.WriteLine($"Сумма квадратных корней всех целых чисел от 1 до {n} равна {sumOfSquareRoots:F2}");
    }
}
