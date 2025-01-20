using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число студентов в каждой группе (k): ");
        int k = int.Parse(Console.ReadLine());

        double[] group1Ages = new double[k];
        double[] group2Ages = new double[k];

        Console.WriteLine("Введите возраст студентов первой группы:");
        for (int i = 0; i < k; i++)
        {
            group1Ages[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Введите возраст студентов второй группы:");
        for (int i = 0; i < k; i++)
        {
            group2Ages[i] = double.Parse(Console.ReadLine());
        }

        double averageAgeGroup1 = CalculateAverageAge(group1Ages);
        double averageAgeGroup2 = CalculateAverageAge(group2Ages);

        Console.WriteLine($"Средний возраст студентов первой группы: {averageAgeGroup1:F2}");
        Console.WriteLine($"Средний возраст студентов второй группы: {averageAgeGroup2:F2}");
    }

    static double CalculateAverageAge(double[] ages)
    {
        double sum = 0;
        foreach (double age in ages)
        {
            sum += age;
        }
        return sum / ages.Length;
    }
}
