using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTests
{
    [TestClass]
    public class ConstructorTests
    {

        #region Default constructor

        [TestMethod]
        public void Constructor_Default()
        {
            int[,] expected = new int[,]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };
            
            Matrix result = new Matrix();

            Inspector.CheckResultWithExpectation(result, expected);
        }

        #endregion

        #region Constructor with rows and columns count and value for fill

        [TestMethod]
        public void Constructor_WithRowsAndColumnsCount()
        {
            uint rowsCount = 2;
            uint columnsCount = 3;

            int[,] expected = new int[,]
            {
                {0, 0, 0},
                {0, 0, 0}
            };
            
            Matrix result = new Matrix(rowsCount, columnsCount);

            Inspector.CheckResultWithExpectation(result, expected);
        }

        [TestMethod]
        public void Constructor_WithRowsAndColumnsCountAndValue()
        {
            uint rowsCount = 2;
            uint columnsCount = 3;
            int value = 5;

            int[,] expected = new int[,]
            {
                { value, value, value },
                { value, value, value }
            };

            Matrix result = new Matrix(rowsCount, columnsCount, value);

            Inspector.CheckResultWithExpectation(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rows count must be greater than zero.")]
        public void Constructor_WithZeroRowsAndColumn()
        {
            uint rowsCount = 0;
            uint columnsCount = 0;

            Matrix result = new Matrix(rowsCount, columnsCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rows count must be greater than zero.")]
        public void Constructor_WithZeroRows()
        {
            uint rowsCount = 0;
            uint columnsCount = 1;

            Matrix result = new Matrix(rowsCount, columnsCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Columns count must be greater than zero.")]
        public void Constructor_WithZeroColumns()
        {
            uint rowsCount = 1;
            uint columnsCount = 0;

            Matrix result = new Matrix(rowsCount, columnsCount);
        }

        #endregion

        #region Constructor with array

        [TestMethod]
        public void Constructor_WithArray()
        {
            int[,] expected = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            int[,] elementsForResult = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            Matrix result = new Matrix(elementsForResult);

            Inspector.CheckResultWithExpectation(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Array must not be null.")]
        public void Constructor_WithNullArray()
        {
            int[,] elements = null;
            
            Matrix result = new Matrix(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rows count must be greater than zero.")]
        public void Constructor_WithArrayZeroRowAndColSize()
        {
            int[,] elements = new int[0, 0];

            Matrix result = new Matrix(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rows count must be greater than zero.")]
        public void Constructor_WithArrayZeroRowSize()
        {
            int[,] elements = new int[0, 1];

            Matrix result = new Matrix(elements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Columns count must be greater than zero.")]
        public void Constructor_WithArrayZeroColSize()
        {
            int[,] elements = new int[1, 0];

            Matrix result = new Matrix(elements);
        }

        #endregion
        
    }
}
