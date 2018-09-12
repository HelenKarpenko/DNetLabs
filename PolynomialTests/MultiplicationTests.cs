using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;

namespace PolynomialTests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void Multiplication_PolynonialWithTheSameDegree()
        {
            int[] coefForLeftPol = { 1, -2, 3, -4, 5 };
            int[] coefForRightPol = { 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 1, -1, 2, -2, 3, 2, 4, 1, 5 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiplication_LeftLargerThanRight()
        {
            int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
            int[] coefForRightPol = { 1, 1 };
            int[] coefForExpectedPol = { 1, 3, 5, 7, 9, 5 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiplication_RightLargerThanLeft()
        {
            int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
            int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 2, 3, 4, 5, 6, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Left polynomial is null.n")]
        public void Multiplication_LeftIsNull()
        {
            int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };

            Polynomial left = null;
            Polynomial rigth = new Polynomial(coefForRightPol);

            Polynomial result = left * rigth;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Right polynomial is null.n")]
        public void Multiplication_RightIsNull()
        {
            int[] coefForLeftPol = { 1, 1, 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = null;

            Polynomial result = left * right;
        }

        [TestMethod]
        public void Multiplication_LeftDegreeIsZero()
        {
            int[] coefForLeftPol = { };
            int[] coefForRightPol = { 1, 1, 1, 1, 1 };
            int[] coefForExpectedPol = { 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiplication_RightDegreeIsZero()
        {
            int[] coefForLeftPol = { 1, 1, 1, 1, 1 };
            int[] coefForRightPol = { };
            int[] coefForExpectedPol = { 1, 1, 1, 1, 1 };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiplication_RightAndLeftDegreeIsZero()
        {
            int[] coefForLeftPol = { };
            int[] coefForRightPol = { };
            int[] coefForExpectedPol = { };

            Polynomial left = new Polynomial(coefForLeftPol);
            Polynomial right = new Polynomial(coefForRightPol);
            Polynomial expected = new Polynomial(coefForExpectedPol);

            Polynomial result = left * right;
            Assert.AreEqual(expected, result);
        }
    }
}
