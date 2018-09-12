using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class SubtractionTest
    {
        [TestMethod]
        public void Subtraction_MatricesWithTheSameDimension()
        {
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
            int[,] elementsForExpectedMatrix = new int[,]
            {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8}
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Matrix expectedMatrix = new Matrix(elementsForExpectedMatrix);
            Matrix resultMatrix = firstMatrix - secondMatrix;

            Assert.AreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixException), "The matrices must be of the same dimension")]
        public void Subtraction_MatricesWithDifferentDimensions()
        {

            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };
            int[,] elementsForSecondMatrix = new int[,]
            {
                {1, 1},
                {1, 1},
                {1, 1}
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Matrix resultMatrix = firstMatrix - secondMatrix;
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

            Matrix resultMatrix = secondMatrix - firstMatrix;
        }
    }
}
