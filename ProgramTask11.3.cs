using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        double average = CalculateAverage(array);

        Console.WriteLine($"Среднее арифметическое элементов массива: {average:F3}");
    }

    static double CalculateAverage(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return (double)sum / array.Length;
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i > 0)
            {
                Console.Write("; ");
            }
            Console.Write(array[i]);
        }
        Console.WriteLine();
    }
}
