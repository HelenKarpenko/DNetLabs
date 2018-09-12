using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;

namespace PolynomialTests
{
    [TestClass]
    public class SubtractionTest
    {
        //[TestMethod]
        //public void Subtraction_PolynonialWithTheSameDegree()
        //{
        //    int[] coefForLeftPol = { 1, -2, 3, -4, 5 };
        //    int[] coefForRightPol = { 1, 1, 1, 1, 1 };
        //    int[] coefForExpectedPol = { 0, -3, 2, -5, 4 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void Subtraction_LeftLargerThanRight()
        //{
        //    int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
        //    int[] coefForRightPol = { 1, 1 };
        //    int[] coefForExpectedPol = { 0, 1, 3, 4, 5 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void Subtraction_RightLargerThanLeft()
        //{
        //    int[] coefForLeftPol = { 1, 2, 3, 4, 5 };
        //    int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };
        //    int[] coefForExpectedPol = { 0, 1, 2, 3, 4, -1, -1 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "Left polynomial is null.n")]
        //public void Subtraction_LeftIsNull()
        //{
        //    int[] coefForRightPol = { 1, 1, 1, 1, 1, 1, 1 };

        //    Polynomial left = null;
        //    Polynomial rigth = new Polynomial(coefForRightPol);

        //    Polynomial result = left - rigth;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException), "Right polynomial is null.n")]
        //public void Subtraction_RightIsNull()
        //{
        //    int[] coefForLeftPol = { 1, 1, 1, 1, 1, 1, 1 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = null;

        //    Polynomial result = left - right;
        //}

        //[TestMethod]
        //public void Subtraction_LeftDegreeIsZero()
        //{
        //    int[] coefForLeftPol = { };
        //    int[] coefForRightPol = { 1, 1, 1, 1, 1 };
        //    int[] coefForExpectedPol = { -1, -1, -1, -1, -1 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void Subtraction_RightDegreeIsZero()
        //{
        //    int[] coefForLeftPol = { 1, 1, 1, 1, 1 };
        //    int[] coefForRightPol = { };
        //    int[] coefForExpectedPol = { 1, 1, 1, 1, 1 };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void Subtraction_RightAndLeftDegreeIsZero()
        //{
        //    int[] coefForLeftPol = { };
        //    int[] coefForRightPol = { };
        //    int[] coefForExpectedPol = { };

        //    Polynomial left = new Polynomial(coefForLeftPol);
        //    Polynomial right = new Polynomial(coefForRightPol);
        //    Polynomial expected = new Polynomial(coefForExpectedPol);

        //    Polynomial result = left - right;
        //    Assert.AreEqual(expected, result);
        //}
    }
}
