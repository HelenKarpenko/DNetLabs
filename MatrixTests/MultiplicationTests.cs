using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void Multiplication_ColumnsEqualsToRows()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2},
                {4, 5},
                {7, 8}
            };
            int[,] elementsForSecondMatrix = new int[,]
            {
                {2, 3, 4},
                {5, 6, 7},
            };
            int[,] elementsForExpectedMatrix = new int[,]
            {
                {12, 15, 18},
                {33, 42, 51},
                {54, 69, 84}
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Matrix expectedMatrix = new Matrix(elementsForExpectedMatrix);
            Matrix resultMatrix = firstMatrix * secondMatrix;

            Assert.AreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixException), "The number of columns of the first matrix must coincide with the number of rows of the second matrix")]
        public void Sum_ColumnNonEqualsToRow()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            int[,] elementsForSecondMatrix = new int[,]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1}
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Matrix resultMatrix = firstMatrix * secondMatrix;
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixException), "Matrix is null")]
        public void Sum_MatrixIsNull()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = null;

            Matrix resultMatrix = secondMatrix * firstMatrix;
        }

        [TestMethod]
        public void Multiplication_MatrixWithValue()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2},
                {4, 5},
                {7, 8}
            };

            int value = 2;

            int[,] elementsForExpectedMatrix = new int[,]
            {
                { 2, 4 },
                { 8, 10},
                {14, 16}
            };

            Matrix matrix = new Matrix(elementsForMatrix);

            Matrix expectedMatrix = new Matrix(elementsForExpectedMatrix);
            Matrix resultMatrix = matrix * value;

            Assert.AreEqual(expectedMatrix, resultMatrix);
        }
    }
}
