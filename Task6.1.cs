using System;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine ("Введите текст на русском языке: ");
        var text = Console.ReadLine ();
        Console.WriteLine (Translate(text));

        Console.ReadKey ();
    }

    static string Translate(string s)
    {
         return s.ToUpper()
        .Replace("А", "A")
        .Replace("Б", "B")
        .Replace("В", "V")
        .Replace("Г", "G")
        .Replace("Д", "D")
        .Replace("E", "E")
        .Replace("Ж", "ZH")
        .Replace ("З", "Z")
        .Replace("И", "I")
        .Replace("Й", "I")
        .Replace ("K", "K")
        .Replace ("Л", "L")
        .Replace("М", "M")
        .Replace("Н", "N")
        .Replace("О", "O")
        .Replace("П", "P")
        .Replace("Р", "R")
        .Replace("С", "S")
        .Replace("Т", "T")
        .Replace("У", "U")
        .Replace("Ф", "F")
        .Replace("Х", "KH")
        .Replace("Ц", "TS")
        .Replace("Ч", "CH")
        .Replace("Ш", "SH")
        .Replace("Щ", "SHCH")
        .Replace("Ъ", "IE")
        .Replace("Ы", "Y")
        .Replace("Ь", "")
        .Replace("Ю", "IU")
        .Replace("Я", "IA");
    }
}