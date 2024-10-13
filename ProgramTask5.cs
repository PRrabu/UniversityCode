using System;
internal class Program
{
    static void Main(string[] args)
    {
        double y = F(2, 3, 1) + F(3, 8, 5) +F(5, 6, 1);
        Console.WriteLine("x = " + Math.Round(y,3));

        Console.ReadKey(); 
    }

static double F(double a, double b, double c)
{
    return Math.Sqrt((c+Math.Pow(Math.Tan(a),2))/b);
}
}