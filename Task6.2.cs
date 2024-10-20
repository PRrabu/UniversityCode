using System;

internal class Program
{
    static void Main(string[] args)
    {
        string word = "кинематограф";


        string word1 = word.Remove(0, 8) + word.Substring(7, 1) + word.Substring(4, 2) + word.Substring(2, 1);

    
        string word2 = word.Substring(4,1) + word.Substring(3, 1) + word.Substring(6, 1) + word.Substring(9, 1) + word.Substring(7, 1);

        Console.WriteLine("Первое слово: " + word1);
        Console.WriteLine("Второе слово: " + word2);
    }
}
