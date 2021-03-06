﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void Sum_MatricesWithTheSameDimension()
        {
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            int[,] elementsForRightMatrix = new int[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };
            int[,] elementsForExpectedMatrix = new int[,]
            {
                {2, 3, 4},
                {5, 6, 7},
                {8, 9, 10}
            };

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = new Matrix(elementsForRightMatrix);
            Matrix expectedMatrix = new Matrix(elementsForExpectedMatrix);

            Matrix result = left + right;

            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixException), "Matrixes have different dimensions.")]
        public void Sum_MatricesWithDifferentDimensions()
        {
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };
            int[,] elementsForRightMatrix = new int[,]
            {
                {1, 1},
                {1, 1},
                {1, 1}
            };

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = new Matrix(elementsForRightMatrix);

            Matrix result = left + right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Sum_MatricesIsNull()
        {
            Matrix left = null;
            Matrix right = null;

            Matrix result = right + left;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Sum_LeftIsNull()
        {
            int[,] elementsForRightMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Matrix left = null;
            Matrix right = new Matrix(elementsForRightMatrix);

            Matrix result = right + left;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Sum_RightIsNull()
        {
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = null;

            Matrix result = right + left;
        }
    }
}
