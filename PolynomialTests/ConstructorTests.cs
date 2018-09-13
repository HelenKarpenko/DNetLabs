using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolynomialLib;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialTests
{
    [TestClass]
    public class ConstructorTests
    {
        #region Constructor with array

        [TestMethod]
        public void Constructor_WithArray()
        {
            int[] array = { 1, 2, 3, 4 };
            uint expectedDegree = (uint)array.Length - 1;

            Polynomial result = new Polynomial(array);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            for (uint i = 0; i < array.Length; i++)
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
            uint expectedDegree = 0 ;

            Polynomial result = new Polynomial(array);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        [TestMethod]
        public void Constructor_WithZeroArray_NormalizeDictionary()
        {
            int[] array = { 0, 0, 0, 0 };
            uint expectedDegree = 0;

            Polynomial result = new Polynomial(array);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        [TestMethod]
        [ExpectedException(typeof(PolynomialException), "These coefficients do not correspond to the polynomial")]
        public void Constructor_ArrayWithnIncorrectCoef()
        {
            int[] array = { 9 };

            Polynomial result = new Polynomial(array);
        }

        [TestMethod]
        public void Constructor_ArrayWithnCorrectCoef()
        {
            int[] array = { 0 };
            uint expectedDegree = 0;

            Polynomial result = new Polynomial(array);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        #endregion

        #region Constructor with dictionary

        [TestMethod]
        public void Constructor_WithDictionary()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, 5);
            dictionary.Add(5, 5);
            dictionary.Add(25, 25);
            dictionary.Add(100, 35);
            dictionary.Add(50, 45);

            uint expectedDegree = dictionary.Keys.Max();

            Polynomial result = new Polynomial(dictionary);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);

            foreach (uint key in dictionary.Keys)
            {
                Assert.AreEqual(result.Coefficients[key], dictionary[key]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Сoefficient dictionary is null.")]
        public void Constructor_WithNullDictionary()
        {
            Dictionary<uint, int> dictionary = null;

            Polynomial result = new Polynomial(dictionary);
        }

        [TestMethod]
        public void Constructor_WithEmptyDictionary()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
            uint expectedDegree = 0;

            Polynomial result = new Polynomial(dictionary);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        [TestMethod]
        [ExpectedException(typeof(PolynomialException), "These coefficients do not correspond to the polynomial")]
        public void Constructor_WithIncorrectDictionary()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, 9);

            Polynomial result = new Polynomial(dictionary);
        }

        [TestMethod]
        public void Constructor_WithDictionaryZeroDegree()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, 0);

            uint expectedDegree = 0;

            Polynomial result = new Polynomial(dictionary);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        [TestMethod]
        public void Constructor_WithZeroDictionary_NormalizeDictionary()
        {
            Dictionary<uint, int> dictionary = new Dictionary<uint, int>();

            dictionary.Add(0, 0);
            dictionary.Add(1, 0);
            dictionary.Add(2, 0);

            uint expectedDegree = 0;

            Polynomial result = new Polynomial(dictionary);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Degree, expectedDegree);
            Assert.AreEqual(result.Coefficients[0], 0);
        }

        #endregion
    }
}
