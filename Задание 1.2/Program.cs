using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int size = 10000;
        int runs = 7;
        int totalComparisons = 0;

        int[] array = GenerateArray(size, 0, 9999, random);

        Array.Sort(array);

        Console.WriteLine("Розмір масиву: " + size);
        Console.WriteLine("Кількість запусків: " + runs);
        Console.WriteLine();

        for (int i = 1; i <= runs; i++)
        {
            int target = array[random.Next(0, array.Length)];

            int comparisons = 0;

            int index = BinarySearch(array, target, ref comparisons);

            Console.WriteLine("Запуск " + i);
            Console.WriteLine("Шуканий елемент: " + target);
            Console.WriteLine("Знайдений індекс: " + index);
            Console.WriteLine("Кількість порівнянь: " + comparisons);
            Console.WriteLine();

            totalComparisons += comparisons;
        }

        double averageComparisons = (double)totalComparisons / runs;

        Console.WriteLine("Середня кількість порівнянь: " + averageComparisons.ToString("F2"));

        Console.ReadKey();
    }

    static int[] GenerateArray(int size, int min, int max, Random random)
    {
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(min, max + 1);
        }

        return arr;
    }

    static int BinarySearch(int[] arr, int target, ref int comparisons)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            comparisons++;
            if (arr[middle] == target)
            {
                return middle;
            }

            comparisons++;
            if (arr[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }
}