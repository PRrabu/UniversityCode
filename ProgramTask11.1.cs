using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите натуральное число b: ");
        int b = int.Parse(Console.ReadLine());

        int[] sequence = new int[15];
        
        for (int n = 0; n < 15; n++)
        {
            sequence[n] = PowerOfTwo(n) - b;
        }

        PrintArray(sequence);
    }
    static int PowerOfTwo(int exponent)
    {
        int result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= 2;
        }
        return result;
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
