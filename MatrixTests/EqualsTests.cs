using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class EqualsTests
    {
        [TestMethod]
        public void Equals_MatrixIsEqualsToItSelf()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix matrix = new Matrix(elementsForMatrix);

            Assert.IsTrue(matrix.Equals(matrix));
        }

        [TestMethod]
        public void Equals_EqualMatrices()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix first = new Matrix(elementsForMatrix);
            Matrix second = new Matrix(elementsForMatrix);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_NonEqualMatrices()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            int[,] elementsForSecondMatrix = new int[,]
            {
                {9, 8, 7},
                {6, 5, 4},
                {3, 2, 1}
            };

            Matrix first = new Matrix(elementsForFirstMatrix);
            Matrix second = new Matrix(elementsForSecondMatrix);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_MatricesWithDifferentRowsNum()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            int[,] elementsForSecondMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {0, 0, 0}
            };

            Matrix first = new Matrix(elementsForFirstMatrix);
            Matrix second = new Matrix(elementsForSecondMatrix);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_MatricesWithDifferentColumnsNum()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {0, 0, 0}
            };

            int[,] elementsForSecondMatrix = new int[,]
            {
                {1, 2},
                {4, 5},
                {0, 0}
            };

            Matrix first = new Matrix(elementsForFirstMatrix);
            Matrix second = new Matrix(elementsForSecondMatrix);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_MatricesWithNull()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {0, 0, 0}
            };

            Matrix first = new Matrix(elementsForFirstMatrix);
            Matrix second = null;

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void HashCode_EqualMatrices()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix first = new Matrix(elementsForMatrix);
            Matrix second = new Matrix(elementsForMatrix);

            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void HashCode_NonEqualMatrices()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            int[,] elementsForSecondMatrix = new int[,]
            {
                {9, 8, 7},
                {6, 5, 4},
                {3, 2, 1}
            };

            Matrix first = new Matrix(elementsForFirstMatrix);
            Matrix second = new Matrix(elementsForSecondMatrix);

            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
