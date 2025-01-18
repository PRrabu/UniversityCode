using System; 
    internal class Program         
    { 
        static void Main(string[] args) 
        { 
 
            var m = GetNumber("m"); 
            var n = GetNumber("n"); 
 
            if (IsStatementTrue(m, n)) 
                Console.WriteLine("Утверждение истинно"); 
            else  
                Console.WriteLine("Утверждение ложно"); 
 
            Console.ReadKey(); 
 
        } 
 
        static bool IsStatementTrue (int m, int n) 
        { 
            return m > 10 && n > 10; 
 
        } 
 
        static int GetNumber(string numberName) 
        { 
            Console.WriteLine($"Введите число {numberName}"); 
            return int.Parse(Console.ReadLine()); 
        } 
 
    } 