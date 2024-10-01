using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число n (10 ≤ n ≤ 999 и число десятков не равно нулю): ");
        string input = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(input, out int n) && n >= 10 && n <= 999 && (n / 10) % 10 != 0)
        {
            int x = FindX(n);
            Console.WriteLine($"Исходное трехзначное число x: {x}");
        }
        else
        {
            Console.WriteLine("Введенное число n не соответствует условиям задачи.");
        }
    }

    static int FindX(int n)
    {
        string nStr = n.ToString();
        
        char secondDigit = nStr[0];
        
        int remainingNumber = int.Parse(nStr.Substring(1));
        
        string xStr = remainingNumber.ToString();
        xStr = xStr[0] + secondDigit.ToString() + xStr.Substring(1);
        
        return int.Parse(xStr);
    }
}
