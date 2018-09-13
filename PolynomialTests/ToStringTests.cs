using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;
using System.Collections.Generic;

namespace PolynomialTests
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToString_SimplePolynomial()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(2, 5);
            dictionary.Add(3, 0);
            dictionary.Add(1, 4);
            dictionary.Add(5, 7);
            dictionary.Add(0, 4);
            dictionary.Add(6, 0);

            string expectedStr = "7x^5 + 5x^2 + 4x + 4 = 0";

            Polynomial polynomial = new Polynomial(dictionary);
            Assert.AreEqual(expectedStr, polynomial.ToString());
        }

        [TestMethod]
        public void ToString_PolynomialWithLastCoefEqualsOne()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(100, 1);
            dictionary.Add(0, 1);

            string expectedStr = "x^100 + 1 = 0";

            Polynomial polynomial = new Polynomial(dictionary);
            Assert.AreEqual(expectedStr, polynomial.ToString());
        }

        [TestMethod]
        public void ToString_ZeroPolynomial()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, 0);
            dictionary.Add(1, 0);
            dictionary.Add(2, 0);
            dictionary.Add(3, 0);

            string expectedStr = "0 = 0";

            Polynomial polynomial = new Polynomial(dictionary);
            Assert.AreEqual(expectedStr, polynomial.ToString());
        }

        [TestMethod]
        public void ToString_PolynomialWithNegativeCoef()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, -3);
            dictionary.Add(1, -4);
            dictionary.Add(2, -8);
            dictionary.Add(3, -6);

            string expectedStr = "-6x^3 + -8x^2 + -4x + -3 = 0";

            Polynomial polynomial = new Polynomial(dictionary);
            Assert.AreEqual(expectedStr, polynomial.ToString());
        }
    }
}
