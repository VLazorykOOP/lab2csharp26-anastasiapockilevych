using System;

class Program
{
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("                ГОЛОВНЕ МЕНЮ               ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1 - Завдання 1 (ОДНОВИМІРНИЙ масив: не діляться на 7)");
            Console.WriteLine("2 - Завдання 1 (ДВОВИМІРНИЙ масив: не діляться на 7)");
            Console.WriteLine("3 - Завдання 2 (Мінімум з додатних елементів)");
            Console.WriteLine("4 - Завдання 3 (Симетричність матриці)");
            Console.WriteLine("5 - Завдання 4 (Східчастий масив і вектор X)");
            Console.WriteLine("0 - ВИХІД");
            Console.WriteLine("=========================================");
            Console.Write("Оберіть номер завдання: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Task1_1D();
                    break;
                case "2":
                    Task1_2D();
                    break;
                case "3":
                    Task2();
                    break;
                case "4":
                    Task3();
                    break;
                case "5":
                    Task4();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Завершення роботи програми.");
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, введіть число від 0 до 5.");
                    break;
            }
        }
    }

    static void Task1_1D()
    {
        Console.Write("Введіть розмір одновимірного масиву: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Помилка вводу!");
            return;
        }

        int[] array = new int[n];
        Console.WriteLine("Масив:");
        for (int i = 0; i < n; i++)
        {
            array[i] = rnd.Next(1, 20);
            Console.Write(array[i] + " ");
        }

        Console.WriteLine("\nІндекси елементів, які не діляться на 7:");
        for (int i = 0; i < n; i++)
        {
            if (array[i] % 7 != 0)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }

    static void Task1_2D()
    {
        Console.Write("Введіть кількість рядків: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0) return;
        Console.Write("Введіть кількість стовпців: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0) return;

        int[,] array = new int[rows, cols];
        Console.WriteLine("Масив:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = rnd.Next(1, 20);
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Індекси [рядок, стовпець] елементів, які не діляться на 7:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] % 7 != 0)
                {
                    Console.Write($"[{i},{j}] ");
                }
            }
        }
        Console.WriteLine();
    }

    static void Task2()
    {
        Console.Write("Введіть розмірність масиву n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

        double[] array = new double[n];
        Console.WriteLine("Елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            array[i] = (rnd.NextDouble() * 20) - 10;
            Console.Write($"{array[i]:F2}  ");
        }
        Console.WriteLine();

        double minPositive = double.MaxValue;
        bool hasPositive = false;

        for (int i = 0; i < n; i++)
        {
            if (array[i] > 0 && array[i] < minPositive)
            {
                minPositive = array[i];
                hasPositive = true;
            }
        }

        if (hasPositive)
            Console.WriteLine($"Мінімум серед додатних елементів: {minPositive:F2}");
        else
            Console.WriteLine("У масиві немає додатних елементів.");
    }

    static void Task3()
    {
        Console.Write("Введіть розмірність квадратної матриці (n x n): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

        int[,] matrix = new int[n, n];

        Console.Write("Згенерувати симетричну матрицю для перевірки? (y/n): ");
        bool forceSymmetric = Console.ReadLine().ToLower() == "y";

        Console.WriteLine("Матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (forceSymmetric && i > j)
                    matrix[i, j] = matrix[j, i];
                else if (i <= j || !forceSymmetric)
                    matrix[i, j] = rnd.Next(1, 10);

                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        bool isSymmetric = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] != matrix[j, i])
                {
                    isSymmetric = false;
                    break;
                }
            }
            if (!isSymmetric) break;
        }

        Console.WriteLine(isSymmetric
            ? "Матриця є симетричною відносно головної діагоналі."
            : "Матриця НЕ є симетричною.");
    }

    static void Task4()
    {
        Console.Write("Введіть кількість рядків східчастого масиву (n): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

        int[][] jaggedArray = new int[n][];
        int[] vectorX = new int[n];

        Console.WriteLine("Вектор X:");
        for (int i = 0; i < n; i++)
        {
            vectorX[i] = rnd.Next(100, 999);
            Console.Write(vectorX[i] + " ");
        }
        Console.WriteLine("\n\nПочатковий східчастий масив:");

        for (int i = 0; i < n; i++)
        {
            int m = rnd.Next(4, 8);
            jaggedArray[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = rnd.Next(1, 10);
                Console.Write(jaggedArray[i][j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < jaggedArray[i].Length; j += 2)
            {
                jaggedArray[i][j] = vectorX[i];
            }
        }

        Console.WriteLine("\nМасив після заміни парних (за рахунком) стовпців на елементи вектора X:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
