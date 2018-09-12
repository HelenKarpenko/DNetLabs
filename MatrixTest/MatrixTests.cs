using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Sum_MatricesWithTheSameDimension()
        {
            var array = new[,]
            {
                {0.1, 0.2, 0.3, 0.4, 0.5},
                {1.1, 1.2, 1.3, 1.4, 1.5},
                {2.1, 2.2, 2.3, 2.4, 2.5},
                {3.1, 3.2, 3.3, 3.4, 3.5},
            };
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            int[,] elementsForSecondMatrix = new int[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };
            int[,] elementsForResultMatrix = new int[,]
            {
                {2, 3, 4 },
                {5, 6, 7 },
                {8, 9, 10}
            };

            Matrix.Matrix firstMatrix = new Matrix.Matrix(elementsForFirstMatrix);
            Matrix.Matrix secondMatrix = new Matrix.Matrix(elementsForSecondMatrix);
            Matrix.Matrix resultMatrix = firstMatrix + secondMatrix;

            Assert.AreEqual(resultMatrix.Elements, elementsForResultMatrix);
        }
    }
}
