using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;

namespace PolynomialTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_WithArray()
        {
            int[] array = { 1, 2, 3, 4 };
            int expectedDegree = array.Length;

            Polynomial result = new Polynomial(array);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(result.Coefficients[i], array[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Сoefficient array is null.")]
        public void Constructor_WithNullArray()
        {
            int[] array = null;

            Polynomial result = new Polynomial(array);
        }

        [TestMethod]
        public void Constructor_WithEmptyArray()
        {
            int[] array = { };

            Polynomial result = new Polynomial(array);
        }

        //public Polynomial(uint degree) : this(new int[degree])
        //{
        //}

        //public Polynomial(int[] coef)
        //{
        //    Coefficients = coef;
        //}

        //public Polynomial(Tuple<int, uint>[] coefDictionary)
        //{
        //    Coefficients = new int[coefDictionary.GetLength(0)];
        //    for (int i = 0; i < coefDictionary.GetLength(0); i++)
        //    {
        //        Coefficients[coefDictionary[i].Item2] = coefDictionary[i].Item1;
        //    }
        //}
    }
}
