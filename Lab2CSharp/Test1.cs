using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class ArrayProcessorTests
{
    [TestMethod]
    public void Task1_1D_Correct_Passes()
    {
        int[] array = { 7, 14, 8, 21, 3 };

        List<int> result = ArrayProcessor.GetIndicesNotDivisibleBy7(array);

        CollectionAssert.AreEqual(new List<int> { 2, 4 }, result);
    }

    [TestMethod]
    public void Task1_1D_Incorrect_Fails()
    {
        int[] array = { 7, 14, 21, 28 };

        List<int> result = ArrayProcessor.GetIndicesNotDivisibleBy7(array);

        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
    public void Task1_2D_Correct_Passes()
    {
        int[,] array = {
            { 7, 8 },
            { 14, 15 }
        };

        var result = ArrayProcessor.GetIndicesNotDivisibleBy7_2D(array);

        var expected = new List<(int, int)> { (0, 1), (1, 1) };
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Task1_2D_Incorrect_Fails()
    {
        int[,] array = {
            { 7, 14 },
            { 21, 28 }
        };

        var result = ArrayProcessor.GetIndicesNotDivisibleBy7_2D(array);

        Assert.AreEqual(5, result.Count);
    }

    [TestMethod]
    public void Task2_Correct_Passes()
    {
        double[] array = { -5.0, 0.0, 3.5, 2.1, 8.0 };

        double result = ArrayProcessor.FindMinPositive(array);

        Assert.AreEqual(2.1, result);
    }

    [TestMethod]
    public void Task2_Incorrect_Fails()
    {
        double[] array = { -5.0, -2.0, 0.0 };

        double result = ArrayProcessor.FindMinPositive(array);

        Assert.AreEqual(0.0, result);
    }

    [TestMethod]
    public void Task3_Correct_Passes()
    {
        int[,] symmetricMatrix = {
            { 1, 2, 3 },
            { 2, 4, 5 },
            { 3, 5, 6 }
        };

        bool result = ArrayProcessor.IsSymmetric(symmetricMatrix);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Task3_Incorrect_Fails()
    {
        int[,] asymmetricMatrix = {
            { 1, 2, 3 },
            { 9, 4, 5 },
            { 3, 5, 6 }
        };

        bool result = ArrayProcessor.IsSymmetric(asymmetricMatrix);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Task4_Correct_Passes()
    {
        int[][] jaggedArray = new int[][]
        {
            new int[] { 1, 2, 3, 4 },
            new int[] { 5, 6, 7 }
        };
        int[] vectorX = { 99, 88 };

        ArrayProcessor.ReplaceColumnsWithVector(jaggedArray, vectorX);

        Assert.AreEqual(99, jaggedArray[0][1]);
        Assert.AreEqual(99, jaggedArray[0][3]);
        Assert.AreEqual(88, jaggedArray[1][1]);
    }

    [TestMethod]
    public void Task4_Incorrect_Fails()
    {
        int[][] jaggedArray = new int[][]
        {
            new int[] { 1 },
            new int[] { 5 }
        };
        int[] vectorX = { 99, 88 };

        ArrayProcessor.ReplaceColumnsWithVector(jaggedArray, vectorX);

        Assert.AreEqual(99, jaggedArray[0][0]);
    }
}