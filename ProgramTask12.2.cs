using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int[] sums = CalculateOddElementSums(array);

        Console.WriteLine("Индексы столбцов и значения сумм нечетных элементов:");
        for (int col = 0; col < sums.Length; col++)
        {
            Console.WriteLine($"Столбец {col + 1}: сумма = {sums[col]}");
        }
    }

    static int[] CalculateOddElementSums(int[,] array)
    {
        int columns = array.GetLength(1);
        int[] sums = new int[columns];

        for (int col = 0; col < columns; col++)
        {
            int sum = 0;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                if (array[row, col] % 2 != 0)
                {
                    sum += array[row, col];
                }
            }
            sums[col] = sum;
        }

        return sums;
    }
}
