using System;
using System.Collections.Generic;

public class ArrayProcessor
{
    public static List<int> GetIndicesNotDivisibleBy7(int[] array)
    {
        var indices = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 7 != 0) indices.Add(i);
        }
        return indices;
    }

    public static List<(int row, int col)> GetIndicesNotDivisibleBy7_2D(int[,] array)
    {
        var indices = new List<(int row, int col)>();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] % 7 != 0) indices.Add((i, j));
            }
        }
        return indices;
    }

    public static double FindMinPositive(double[] array)
    {
        double min = double.MaxValue;
        bool found = false;

        foreach (var val in array)
        {
            if (val > 0 && val < min)
            {
                min = val;
                found = true;
            }
        }
        return found ? min : double.NaN;
    }

    public static bool IsSymmetric(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols) return false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] != matrix[j, i]) return false;
            }
        }
        return true;
    }

    public static void ReplaceColumnsWithVector(int[][] jaggedArray, int[] vectorX)
    {
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 1; j < jaggedArray[i].Length; j += 2)
            {
                jaggedArray[i][j] = vectorX[i];
            }
        }
    }
}