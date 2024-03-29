﻿// Объявить одномерный(5 элементов) массив с именем A и двумерный массив (3 строки, 4 столбца)
// дробных чисел с именем B. Заполнить одномерный массив А числами, введенными с клавиатуры пользователем,
// а двумерный массив В случайными числами с помощью циклов. Вывести на экран значения массивов:
// массива А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент,
// минимальный элемент, общую сумму всех элементов, общее произведение всех элементов,
// сумму четных элементов массива А, сумму нечетных столбцов массива В.

class Program
{
    static void Main()
    {
        double[] A = new double[5];
        Console.WriteLine("Введите 5 чисел для массива A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = Convert.ToDouble(Console.ReadLine());
        }

        double[,] B = new double[3, 4];
        Random rand = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = rand.NextDouble() * 100;
            }
        }

        Console.Write("Массив A: ");
        foreach (var num in A)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\nМассив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(B[i, j] + "\t");
            }
            Console.WriteLine();
        }

        double maxA = A.Max();
        double minA = A.Min();
        double maxB = B.Cast<double>().Max();
        double minB = B.Cast<double>().Min();

        double sumA = A.Sum();
        double sumB = B.Cast<double>().Sum();

        double prodA = A.Aggregate((x, y) => x * y);
        double prodB = B.Cast<double>().Aggregate((x, y) => x * y);

        double sumEvenA = A.Where(num => num % 2 == 0).Sum();

        double sumOddColumnsB = 0;
        for (int j = 0; j < 4; j++)
        {
            double columnSum = 0;
            for (int i = 0; i < 3; i++)
            {
                columnSum += B[i, j];
            }
            if (j % 2 != 0)
            {
                sumOddColumnsB += columnSum;
            }
        }

        Console.WriteLine("\nОбщий максимальный элемент:");
        Console.WriteLine("Массив A: " + maxA);
        Console.WriteLine("Массив B: " + maxB);

        Console.WriteLine("\nОбщий минимальный элемент:");
        Console.WriteLine("Массив A: " + minA);
        Console.WriteLine("Массив B: " + minB);

        Console.WriteLine("\nОбщая сумма всех элементов:");
        Console.WriteLine("Массив A: " + sumA);
        Console.WriteLine("Массив B: " + sumB);

        Console.WriteLine("\nОбщее произведение всех элементов:");
        Console.WriteLine("Массив A: " + prodA);
        Console.WriteLine("Массив B: " + prodB);

        Console.WriteLine("\nСумма четных элементов массива A: " + sumEvenA);
        Console.WriteLine("Сумма нечетных столбцов массива B: " + sumOddColumnsB);
    }
}