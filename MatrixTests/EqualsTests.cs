using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class EqualsTests
    {
        [TestMethod]
        public void Equals_MatrixIsEqualsToItSelf_IsTrue()
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
        public void Equals_EqualMatrices_IsTrue()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix firstMatrix = new Matrix(elementsForMatrix);
            Matrix secondMatrix = new Matrix(elementsForMatrix);

            Assert.IsTrue(firstMatrix.Equals(secondMatrix));
        }

        [TestMethod]
        public void EqualsOperator_EqualMatrices_IsTrue()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            
            Matrix firstMatrix = new Matrix(elementsForMatrix);
            Matrix secondMatrix = new Matrix(elementsForMatrix);

            Assert.IsTrue(firstMatrix == secondMatrix);
        }

        [TestMethod]
        public void Equals_NonEqualMatrices_IsFalse()
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

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Assert.IsFalse(firstMatrix.Equals(secondMatrix));
        }

        [TestMethod]
        public void EqualsOperator_NonEqualMatrices_IsTrue()
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

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Assert.IsTrue(firstMatrix != secondMatrix);
        }

        [TestMethod]
        public void Equals_MatricesWithDifferentRowsNum_IsTrue()
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

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Assert.IsTrue(firstMatrix != secondMatrix);
        }

        [TestMethod]
        public void Equals_MatricesWithDifferentColumnsNum_IsTrue()
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

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Assert.IsTrue(firstMatrix != secondMatrix);
        }

        [TestMethod]
        public void Equals_MatricesWithNull_IsTrue()
        {
            int[,] elementsForFirstMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {0, 0, 0}
            };

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = null;

            Assert.IsTrue(firstMatrix != secondMatrix);
        }

        [TestMethod]
        public void HashCode_EqualMatrices_AreEqual()
        {
            int[,] elementsForMatrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix firstMatrix = new Matrix(elementsForMatrix);
            Matrix secondMatrix = new Matrix(elementsForMatrix);

            Assert.AreEqual(firstMatrix.GetHashCode(), secondMatrix.GetHashCode());
        }

        [TestMethod]
        public void HashCode_NonEqualMatrices_AreNotEqual()
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

            Matrix firstMatrix = new Matrix(elementsForFirstMatrix);
            Matrix secondMatrix = new Matrix(elementsForSecondMatrix);

            Assert.AreNotEqual(firstMatrix.GetHashCode(), secondMatrix.GetHashCode());
        }
    }
}
