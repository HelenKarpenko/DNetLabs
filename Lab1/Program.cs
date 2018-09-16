using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;
using PolynomialLib;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] elements = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Matrix matrix = new Matrix(elements);
            Console.Write(matrix);

            //FileProcessor.ToBinary(matrix, "matrix.mtx");

            //var des = FileProcessor.FromBinary("matrix.mtx");
            //Console.Write(des);

            FileProcessor.ToJSON(matrix, "matrix.json");

            var des2 = FileProcessor.FromJSON ("matrix.json");
            Console.Write(des2);

            Polynomial polynomial = new Polynomial(new int[]{ 1, 0, 0 , -5, 2, 3, 4});
            Console.Write(polynomial); 
            Console.ReadKey();
        }
    }
}
