using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    static class Inspector
    {
        public static void CheckResultWithExpectation(Matrix result, int[,] expected)
        {
            CheckDimension(result, expected);

            CheckElements(result, expected);
        }

        public static void CheckDimension(Matrix result, int[,] expected)
        {
            Assert.AreEqual(result.RowsCount, (uint)expected.GetLength(0));
            Assert.AreEqual(result.ColumnsCount, (uint)expected.GetLength(1));
        }

        public static void CheckElements(Matrix result, int[,] expected)
        {
            for (int i = 0; i < result.RowsCount; i++)
            {
                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    Assert.AreEqual(result[i, j], expected[i, j]);
                }
            }
        }

        public static void CheckElements(int[] elements, int[] expected)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Assert.AreEqual(elements[i], expected[i]);
            }
        }
    }
}
