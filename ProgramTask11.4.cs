using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Введите число k: ");
        int k = int.Parse(Console.ReadLine());

        int[] remainders = GetRemainders(array, k);

        Console.WriteLine("Массив остатков:");
        PrintArray(remainders);
    }

    static int[] GetRemainders(int[] array, int k)
    {
        int[] remainders = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            remainders[i] = array[i] % k;
        }
        return remainders;
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
