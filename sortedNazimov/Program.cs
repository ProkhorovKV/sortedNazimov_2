using System;
using System.Diagnostics;

class Program
{
    // Функция быстрой сортировки
    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            // Разбиение массива
            int pivotIndex = Partition(arr, low, high);

            // Рекурсивная сортировка двух частей массива
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }



    // Разбиение массива и возвращение индекса опорного элемента
    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Опорный элемент
        int i = (low - 1); // Индекс для меньших элементов

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                // Меняем элементы местами
                Swap(ref arr[i], ref arr[j]);
            }
        }

        // Меняем опорный элемент с элементом на позиции i+1
        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }



    // Функция для обмена двух элементов
    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }



  
    private static int[] GenerateRandomArray(int size)
    {
        
        Random random = new Random();

        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(1, 100);
        }
        return arr;
    }








    // Главная функция для генерации массива и сортировки
    public static void Main()
    {
        int[] sizes = {1000, 10000, 100000 };

        Console.WriteLine("\n --- Время алгоритма быстрой сортировки --- ");
        foreach (int size in sizes)
        {
            int[] arr = GenerateRandomArray(size);

            // запуск таймера
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Сортировка массива с использованием быстрой сортировки
            QuickSort(arr, 0, arr.Length - 1);

            // остановка таймера
            sw.Stop();
            double elapsedSeconds = sw.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"\nВремя сортировки {size} чисел: {elapsedSeconds:F4} секунд.");

        }

        Console.WriteLine("\n --- Время алгоритма сортировка вставками --- ");
        foreach (int size in sizes)
        {
            int[] arr = GenerateRandomArray(size);

            // запуск таймера
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Сортировка массива с использованием быстрой сортировки
            InsertionSort(arr);

            // остановка таймера
            sw.Stop();
            double elapsedSeconds = sw.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"\nВремя сортировки {size} чисел: {elapsedSeconds:F4} секунд.");

        }

        Console.WriteLine("\n --- Время алгоритма сортировка выбором --- ");
        foreach (int size in sizes)
        {
            int[] arr = GenerateRandomArray(size);

            // запуск таймера
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Сортировка массива с использованием быстрой сортировки
            SelectionSort(arr);

            // остановка таймера
            sw.Stop();
            double elapsedSeconds = sw.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"\nВремя сортировки {size} чисел: {elapsedSeconds:F4} секунд.");

        }




    }




    // Функция сортировки вставками
    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int current = arr[i]; // Текущий элемент
            int j = i - 1;

            // Перемещаем элементы, которые больше текущего, на одну позицию вперед
            while (j >= 0 && arr[j] > current)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            // Вставляем текущий элемент на его правильную позицию
            arr[j + 1] = current;
        }
    }







    // Функция сортировки выбором
    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            // Ищем минимальный элемент в оставшейся части массива
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            // Меняем местами текущий элемент и минимальный элемент
            if (minIndex != i)
            {
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }
    }




}

