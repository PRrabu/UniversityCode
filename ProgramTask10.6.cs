using System;

class Program
{
    static void Main(string[] args)
    {
        for (int number = 100; number <= 999; number++)
        {
            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            if (digit1 != digit2 && digit1 != digit3 && digit2 != digit3)
            {
                Console.WriteLine(number);
            }
        }
    }
}
