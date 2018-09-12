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
            Matrix matrix = new Matrix();
            Console.Write(matrix);

            Polynomial polynomial = new Polynomial(new int[]{ 1, 0, 0 , -5, 2, 3, 4});
            Console.Write(polynomial); 
            Console.ReadKey();
        }
    }
}
