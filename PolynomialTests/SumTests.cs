using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;

namespace PolynomialTests
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void Sum_PolynonialWithTheSameDegree()
        {
            int[] coefForLeftPol = { 1, -2, 3, -4, 5 };
            int[] coefForRightPol = { 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 2, -1, 4, -3, 6 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum_LeftLargerThanRight()
        {
            int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
            int[] coefForRightPol = { 1, 1 };
            int[] coefForExpectedPol = { 2, 3, 3, 4, 5 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum_RightLargerThanLeft()
        {
            int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
            int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 2, 3, 4, 5, 6, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Left polynomial is null.n")]
        public void Sum_LeftIsNull()
        {
            int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };

            Polynomial left = null;
            Polynomial rigth = new Polynomial(coefForRightPol);

            Polynomial result = left + rigth;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Right polynomial is null.n")]
        public void Sum_RightIsNull()
        {
            int[] coefForLeftPol = { 1, 1, 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = null;

            Polynomial result = left + right;
        }

        [TestMethod]
        public void Sum_LeftDegreeIsZero()
        {
            int[] coefForLeftPol = { };
            int[] coefForRightPol = { 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum_RightDegreeIsZero()
        {
            int[] coefForLeftPol = { 1, 1, 1, 1, 1 };
            int[] coefForRightPol = { };
            int[] coefForExpectedPol = { 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum_RightAndLeftDegreeIsZero()
        {
            int[] coefForLeftPol = { };
            int[] coefForRightPol = { };
            int[] coefForExpectedPol = { };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left + right;
            Assert.AreEqual(expected, result);
        }
    }
}
