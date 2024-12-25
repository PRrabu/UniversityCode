using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите натуральное число, в котором все цифры различны: ");
        int number = int.Parse(Console.ReadLine());

        int maxDigit = -1;
        int position = 0;
        int maxDigitPosition = 0;
        int currentPosition = 1;

        while (number > 0)
        {
            int digit = number % 10;
            if (digit > maxDigit)
            {
                maxDigit = digit;
                maxDigitPosition = currentPosition;
            }
            number /= 10;
            currentPosition++;
        }

        Console.WriteLine($"Порядковый номер максимальной цифры (считая справа налево): {maxDigitPosition}");
    }
}
