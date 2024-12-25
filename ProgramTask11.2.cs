using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, -2, 3, -4, 5, -6, 7, -8, 9, -10 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        ChangeSignOfElements(array);

        Console.WriteLine("Измененный массив:");
        PrintArray(array);
    }

    static void ChangeSignOfElements(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = -array[i];
        }
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
