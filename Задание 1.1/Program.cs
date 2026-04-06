using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Random random = new Random();

        int[] sizes = { 1000, 10000, 50000, 100000 };

        for (int i = 0; i < sizes.Length; i++)
        {
            int size = sizes[i];

            int[] arr = GenerateArray(size, 0, 9999, random);

            int[] arr1 = (int[])arr.Clone();
            int[] arr2 = (int[])arr.Clone();

            long insertionComp = 0;
            long insertionMoves = 0;
            double insertionTime = 0;

            long countingComp = 0;
            long countingMoves = 0;
            double countingTime = 0;

            InsertionSort(arr1, ref insertionComp, ref insertionMoves, ref insertionTime);
            CountingSort(arr2, ref countingComp, ref countingMoves, ref countingTime);

            Console.WriteLine("Розмір масиву: " + size);
            Console.WriteLine();

            Console.WriteLine("Insertion Sort:");
            Console.WriteLine("Порівнянь: " + insertionComp);
            Console.WriteLine("Переміщень: " + insertionMoves);
            Console.WriteLine("Час: " + insertionTime.ToString("F2") + " мс");
            Console.WriteLine();

            Console.WriteLine("Counting Sort:");
            Console.WriteLine("Порівнянь: " + countingComp);
            Console.WriteLine("Переміщень: " + countingMoves);
            Console.WriteLine("Час: " + countingTime.ToString("F2") + " мс");
        }
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

    static void InsertionSort(int[] arr, ref long comparisons, ref long moves, ref double time)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 1; i < arr.Length; i++)
        {
            int x = arr[i];
            int j = i - 1;

            while (j >= 0)
            {
                comparisons++;

                if (arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    moves++;
                    j--;
                }
                else
                {
                    break;
                }
            }

            arr[j + 1] = x;
            moves++;
        }

        stopwatch.Stop();
        time = stopwatch.Elapsed.TotalMilliseconds;
    }

    static void CountingSort(int[] arr, ref long comparisons, ref long moves, ref double time)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (arr.Length == 0)
        {
            time = 0;
            return;
        }

        int min = arr[0];
        int max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            comparisons++;
            if (arr[i] < min)
            {
                min = arr[i];
            }

            comparisons++;
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        int range = max - min + 1;
        int[] count = new int[range];

        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - min]++;
        }

        int index = 0;

        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                arr[index] = i + min;
                index++;
                count[i]--;
                moves++;
            }
        }

        stopwatch.Stop();
        time = stopwatch.Elapsed.TotalMilliseconds;
    }
}