using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите факториал числа (например, 120): ");
        int inputFactorial = int.Parse(Console.ReadLine());

        int n = 1;
        int calculatedFactorial = 1;

        while (calculatedFactorial < inputFactorial)
        {
            n++;
            calculatedFactorial *= n;
        }

        if (calculatedFactorial == inputFactorial)
        {
            Console.WriteLine($"Введенное число является факториалом числа {n}.");
        }
        else
        {
            Console.WriteLine("Введенное число не является факториалом.");
        }
    }
}
