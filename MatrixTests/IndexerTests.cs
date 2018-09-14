using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class IndexerTests
    {
        [TestMethod]
        public void Indexer_ByRowAndColIndex()
        {
            int[,] elements = new int[,]
            {
                {  1, -2,  3 },
                { -4,  5, -6 },
                {  9, -8,  7 },
                { -1,  7, -3 },
            };

            Matrix matrix = new Matrix(elements);

            Inspector.CheckElements(matrix, elements);
        }

        [TestMethod]
        public void Indexer_ByRowIndex()
        {
            int[,] elements = new int[,]
            {
                {  1, -2,  3 },
                { -4,  5, -6 },
                {  9, -8,  7 },
                { -1,  7, -3 },
            };

            Matrix matrix = new Matrix(elements);

            int[] expectedRow = { 9, -8, 7 };
            int rowIndex = 2;

            int[] result = matrix[rowIndex];
            Inspector.CheckElements(result, expectedRow);
        }
    }
}
