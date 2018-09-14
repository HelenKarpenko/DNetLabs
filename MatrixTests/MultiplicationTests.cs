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
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2},
                {4, 5},
                {7, 8}
            };
            int[,] elementsForRightMatrix = new int[,]
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

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = new Matrix(elementsForRightMatrix);
            Matrix expectedMatrix = new Matrix(elementsForExpectedMatrix);

            Matrix resultMatrix = left * right;

            Assert.AreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixException), "The number of columns of the first matrix must coincide with the number of rows of the second matrix")]
        public void Multiplication_ColumnNonEqualsToRow()
        {
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            int[,] elementsForRightMatrix = new int[,]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1}
            };

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = new Matrix(elementsForRightMatrix);

            Matrix resultMatrix = left * right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Multiplication_MatricesIsNull()
        {
            Matrix left = null;
            Matrix right = null;

            Matrix result = right * left;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Multiplication_LeftIsNull()
        {
            int[,] elementsForRightMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Matrix left = null;
            Matrix right = new Matrix(elementsForRightMatrix);

            Matrix result = right * left;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Matrix must not be null.")]
        public void Multiplication_RightIsNull()
        {
            int[,] elementsForLeftMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            Matrix left = new Matrix(elementsForLeftMatrix);
            Matrix right = null;

            Matrix result = right * left;
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

            Matrix expected = new Matrix(elementsForExpectedMatrix);
            Matrix result = matrix * value;

            Assert.AreEqual(expected, result);
        }
    }
}
