using System;

internal class Program
{
    static void Main(string[] args)
    {Console.Write("Введите число x: ");
    var x = double.Parse(Console.ReadLine());

    var y = MyFuncion(x);
    Console.WriteLine("f(x) =" + y);

    Console.ReadKey();
    }
    static double MyFuncion(double x){
        //throw new NotImplementedException();
        return Math.Sqrt(Math.Pow(x, 2)+ Math.Sqrt(Math.Pow(x,2)+ 1/Math.Pow(x,2)));
    }
}


