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

        if (AreRowsSorted(array, out int rowIndex, out int colIndex))
        {
            Console.WriteLine("Строки массива упорядочены по возрастанию.");
        }
        else
        {
            Console.WriteLine($"Нарушение порядка: строка {rowIndex + 1}, столбец {colIndex}");
        }
    }

    static bool AreRowsSorted(int[,] array, out int rowIndex, out int colIndex)
    {
        rowIndex = -1;
        colIndex = -1;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 1; j < array.GetLength(1); j++)
            {
                if (array[i, j] < array[i, j - 1])
                {
                    rowIndex = i;
                    colIndex = j;
                    return false;
                }
            }
        }

        return true;
    }
}
