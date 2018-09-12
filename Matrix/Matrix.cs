using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix
    {
        private static int _defaultDimension = 5;

        public int[,] Elements { get; set; }

        public int RowsCount
        {
            get
            {
                return Elements.GetLength(0);
            }
        }
        public int ColumnsCount
        {
            get
            {
                return Elements.GetLength(1);
            }
        }

        public Matrix(int row, int coll, int value = 0)
        {
            if (row <= 0 || coll <= 0) throw new ArgumentException("Row and coll <= 0");

            Elements = new int[row, coll];
            if (value != 0)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < coll; j++)
                    {
                        Elements[i, j] = value;
                    }
                }
            }
        }

        public Matrix() : this(_defaultDimension, _defaultDimension) { }

        public Matrix(int[,] data)
        {
            Elements = data;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left == null || right == null)
                throw new MatrixException("Matrix is null");

            if (left.RowsCount != right.RowsCount ||
               left.ColumnsCount != right.ColumnsCount)
                // Matrixes have different dimensions.
                throw new MatrixException("The matrices must be of the same dimension");

            Matrix result = new Matrix(left.RowsCount, left.ColumnsCount, 0);

            for (int i = 0; i < left.RowsCount; i++)
            {
                for (int j = 0; j < left.ColumnsCount; j++)
                {
                    result.Elements[i, j] = left.Elements[i, j] + right.Elements[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
                throw new MatrixException("Matrix is null");

            if (firstMatrix.RowsCount != secondMatrix.RowsCount ||
              firstMatrix.ColumnsCount != secondMatrix.ColumnsCount)
                throw new MatrixException("The matrices must be of the same dimension");

            Matrix result = new Matrix(firstMatrix.RowsCount, secondMatrix.ColumnsCount);

            for (int i = 0; i < firstMatrix.RowsCount; i++)
            {
                for (int j = 0; j < firstMatrix.ColumnsCount; j++)
                {
                    result.Elements[i, j] = firstMatrix.Elements[i, j] - secondMatrix.Elements[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
                throw new MatrixException("Matrix is null");
            
            if (firstMatrix.ColumnsCount != secondMatrix.RowsCount)
                throw new MatrixException("The number of columns of the first matrix must coincide with the number of rows of the second matrix");

            Matrix result = new Matrix(firstMatrix.RowsCount, secondMatrix.ColumnsCount, 0);
            for (int i = 0; i < firstMatrix.RowsCount; i++)
            {
                for (int j = 0; j < secondMatrix.ColumnsCount; j++)
                {
                    for (int k = 0; k < firstMatrix.ColumnsCount; k++)
                    {
                        result.Elements[i, j] += firstMatrix.Elements[i, k] * secondMatrix.Elements[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix, int value)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Matrix must not be null");

            Matrix result = new Matrix(matrix.Elements);

            for (int i = 0; i < result.RowsCount; i++)
            {
                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    result.Elements[i, j] *= value;
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix matrix = obj as Matrix;

            if (matrix.RowsCount != RowsCount || matrix.ColumnsCount != ColumnsCount)
                return false;
            return Elements.Cast<int>().SequenceEqual(matrix.Elements.Cast<int>());
        }

        public override int GetHashCode()
        {
            int hash = 27;
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    hash = hash * 31 + Elements[i, j];
                }
            }
            return hash;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                sb.Append("{");
                for (int j = 0; j < ColumnsCount; j++)
                {
                    sb.AppendFormat(" {0} ", Elements[i,j]);
                }
                sb.AppendLine("}");
            }
            return sb.ToString();
        }

    }
}
