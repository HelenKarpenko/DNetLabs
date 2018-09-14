using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix : ICloneable
    {
        private static uint _defaultDimension = 5;

        private int[,] _elements { get; set; }

        public int this[int i, int j]
        {
            get
            {
                return _elements[i, j];
            }
            set
            {
                _elements[i, j] = value;
            }
        }

        public int[] this[int byRow]
        {
            get
            {
                int[] row = new int[ColumnsCount];
                for (int i = 0; i < ColumnsCount; i++)
                {
                    row[i] = _elements[byRow, i];
                }
                return row;
            }

            set
            {
                for (int i = 0; i < ColumnsCount; i++)
                {
                    _elements[byRow, i] = value[i];
                }
            }
        }

        public uint RowsCount
        {
            get
            {
                return (uint)_elements.GetLength(0);
            }
        }
        public uint ColumnsCount
        {
            get
            {
                return (uint)_elements.GetLength(1);
            }
        }

        public Matrix(uint rowsCount, uint columnsCount, int value = 0)
        {
            if (rowsCount == 0)
                throw new ArgumentException("Rows count must be greater than zero.");

            if (columnsCount == 0)
                throw new ArgumentException("Columns count must be greater than zero.");

            _elements = new int[rowsCount, columnsCount];

            if (value != 0)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < columnsCount; j++)
                    {
                        this[i, j] = value;
                    }
                }
            }
        }

        public Matrix() : this(_defaultDimension, _defaultDimension) { }

        public Matrix(int[,] data)
        {
            if (data == null)
                throw new ArgumentNullException("data", "Array must not be null.");

            if (data.GetLength(0) == 0)
                throw new ArgumentException("Rows count must be greater than zero.");

            if (data.GetLength(1) == 0)
                throw new ArgumentException("Columns count must be greater than zero.");

            _elements = data;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left == null)
                throw new ArgumentNullException("left", "Matrix must not be null.");

            if (right == null)
                throw new ArgumentNullException("rigth", "Matrix must not be null.");

            if (left.RowsCount != right.RowsCount ||
               left.ColumnsCount != right.ColumnsCount)
                throw new MatrixException("Matrixes have different dimensions.");

            Matrix result = new Matrix(left.RowsCount, left.ColumnsCount, 0);

            for (int i = 0; i < left.RowsCount; i++)
            {
                for (int j = 0; j < left.ColumnsCount; j++)
                {
                    result[i, j] = left[i, j] + right[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left == null)
                throw new ArgumentNullException("left", "Matrix must not be null.");

            if (right == null)
                throw new ArgumentNullException("right", "Matrix must not be null.");

            if (left.RowsCount != right.RowsCount ||
              left.ColumnsCount != right.ColumnsCount)
                throw new MatrixException("Matrixes have different dimensions.");

            Matrix result = new Matrix(left.RowsCount, left.ColumnsCount);

            for (int i = 0; i < left.RowsCount; i++)
            {
                for (int j = 0; j < left.ColumnsCount; j++)
                {
                    result[i, j] = left[i, j] - right[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left == null)
                throw new ArgumentNullException("left", "Matrix must not be null.");

            if (right == null)
                throw new ArgumentNullException("right", "Matrix must not be null.");

            if (left.ColumnsCount != right.RowsCount)
                throw new MatrixException("The number of columns of the first matrix must coincide with the number of rows of the second matrix");

            Matrix result = new Matrix(left.RowsCount, right.ColumnsCount, 0);

            for (int i = 0; i < left.RowsCount; i++)
            {
                for (int j = 0; j < right.ColumnsCount; j++)
                {
                    for (int k = 0; k < left.ColumnsCount; k++)
                    {
                        result[i, j] += left[i, k] * right[k, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix, int value)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Matrix must not be null.");

            Matrix result = (Matrix)matrix.Clone();

            for (int i = 0; i < result.RowsCount; i++)
            {
                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    result[i, j] *= value;
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
            return _elements.Cast<int>().SequenceEqual(matrix._elements.Cast<int>());
        }

        public override int GetHashCode()
        {
            int hash = 27;
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    hash = hash * 31 + this[i, j];
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
                    sb.AppendFormat(" {0} ", this[i,j]);
                }

                sb.AppendLine("}");
            }

            return sb.ToString();
        }

        public object Clone()
        {
            return new Matrix((int[,])_elements.Clone());
        }
    }
}
