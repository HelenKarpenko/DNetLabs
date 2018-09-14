using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;
using System.Collections.Generic;

namespace PolynomialTests
{
    [TestClass]
    public class IncreaseDegreeTests
    {
        //public Polynomial IncreaseDegree(uint newDegree)
        //{
        //    if (newDegree <= Degree) return null;

        //    uint difference = newDegree - Degree;
        //    int[] coefForIncPol = new int[difference].Select(i => 1).ToArray();
        //    Polynomial polynomialForIncrease = new Polynomial(coefForIncPol);

        //    return this * polynomialForIncrease;
        //}

        [TestMethod]
        public void IncreaseDegree_NewLargerThanCurrent()
        {
            Dictionary<uint, int> coef = new Dictionary<uint, int>
            {
                { 0, 1 },
                { 1, 1 },
                { 2, 1 },
            };
            Dictionary<uint, int> coefForExpected = new Dictionary<uint, int>();
            coefForExpected.Add(3, 1);
            coefForExpected.Add(4, 1);
            coefForExpected.Add(5, 1);

            Polynomial polynomial = new Polynomial(coef);
            Polynomial expected = new Polynomial(coefForExpected);

            uint newDegree = 5;
            Polynomial result = Polynomial.IncreaseDegree(polynomial, newDegree);

            Assert.IsNotNull(result);
            Assert.AreEqual(newDegree, result.Degree);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void IncreaseDegree_NewLessThanCurrent()
        {
            Dictionary<uint, int> coef = new Dictionary<uint, int>
            {
                { 0, 1 },
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
            };

            Polynomial polynomial = new Polynomial(coef);

            uint newDegree = 3;
            Polynomial result = Polynomial.IncreaseDegree(polynomial, newDegree);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IncreaseDegree_NewEqualCurrent()
        {
            Dictionary<uint, int> coef = new Dictionary<uint, int>
            {
                { 0, 1 },
                { 1, 1 },
                { 2, 1 },
            };

            Polynomial polynomial = new Polynomial(coef);

            uint newDegree = 2;
            Polynomial result = Polynomial.IncreaseDegree(polynomial, newDegree);

            Assert.IsNull(result);
        }
    }
}
