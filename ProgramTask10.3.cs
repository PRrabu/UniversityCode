using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество чисел (n): ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("Введите числа:");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int maxSequenceLength = GetMaxSequenceLength(numbers);
        Console.WriteLine($"Максимальное значение числа идущих подряд одинаковых чисел: {maxSequenceLength}");
    }

    static int GetMaxSequenceLength(int[] numbers)
    {
        int maxLength = 1;
        int currentLength = 1;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
                currentLength = 1;
            }
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
        }

        return maxLength;
    }
}
