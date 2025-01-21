using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        int k = ReadK();
        long result = CalculateF(k);
        Console.WriteLine($"F({k}) = {result}");
    }

    static int ReadK()
    {
        int k;
        while (true)
        {
            Console.Write("Введите значение k (от 3 до 9): ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out k))
            {
                if (k >= 3 && k <= 9)
                {
                    break;
                }
            }
            Console.WriteLine("Некорректное значение, попробуйте еще раз.");
        }
        return k;
    }

    static List<BigInteger> GeneratePrimeNumbersEndingIn7(int count)
    {
        List<BigInteger> primes = new List<BigInteger>();
        BigInteger number = 7;
        
        while (primes.Count < count)
        {
            if (IsPrime(number))
            {
                primes.Add(number);
            }
            number += 10;
        }
        
        return primes;
    }

    static bool IsPrime(BigInteger number)
    {
        if (number < 2) return false;
        for (BigInteger i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsRaffNumber(BigInteger number, List<BigInteger> set)
    {
        foreach (BigInteger prime in set)
        {
            if (number % prime == 0) return false;
        }
        return true;
    }

    static bool IsPerfectSquare(BigInteger number)
    {
        BigInteger sqrt = (BigInteger)Math.Sqrt((double)number);
        return sqrt * sqrt == number;
    }

    static long CalculateF(int k)
    {
        List<BigInteger> primes = GeneratePrimeNumbersEndingIn7(k);
        primes.Insert(0, 2);
        primes.Insert(1, 5);

        BigInteger Nk = primes.Aggregate((BigInteger)1, (product, prime) => product * prime);
        long sum = 0;

        for (BigInteger i = 7; i < Nk; i += 10)
        {
            if (IsRaffNumber(i, primes) && !IsPerfectSquare(i))
            {
                sum = (sum + (long)(i % 1000000007)) % 1000000007;
            }
        }

        return sum;
    }
}
