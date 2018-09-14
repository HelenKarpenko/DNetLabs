 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class CloneTests
    {
        [TestMethod]
        public void CloneTest()
        {
            int[,] elements = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix matrix = new Matrix(elements);
            Matrix clone = (Matrix)matrix.Clone();

            Assert.IsNotNull(clone);
            Assert.IsTrue(clone != matrix);
            Assert.AreEqual(matrix, clone);
        }
    }
}
