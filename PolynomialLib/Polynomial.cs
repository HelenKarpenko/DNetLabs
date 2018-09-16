using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLib
{
    public class Polynomial : ICloneable
    {
        public Dictionary<uint, int> _coefficients { get; set; }

        public int this[uint i]
        {
            get
            {
                return _coefficients[i];
            }
            set
            {
                _coefficients[i] = value;
            }
        }

        public uint Degree
        {
            get
            {
                return _coefficients.Keys.Max();
            }
        }

        public Polynomial(int[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Сoefficient array is null.");

            if (IsIncorrectCoef(coefficients))
                throw new PolynomialException("These coefficients do not correspond to the polynomial");

            if (coefficients.Length == 0)
                throw new ArgumentException("Array is empty.");

            _coefficients = new Dictionary<uint, int>();
            for (int i = 0; i < coefficients.Length; i++)
            {
                _coefficients.Add((uint)i, coefficients[i]);
            }

            NormalizeDictionary(_coefficients);
        }

        public Polynomial(Dictionary<uint, int> coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Сoefficient dictionary is null.");

            if (coefficients.Count == 0)
                throw new ArgumentException("Dictionary is empty.");

            NormalizeDictionary(coefficients);

            if (IsIncorrectCoef(coefficients))
                throw new PolynomialException("These coefficients do not correspond to the polynomial");

            _coefficients = coefficients;
        }

        private static bool IsIncorrectCoef(int[] polynomial)
        {
            return polynomial.Length == 1 && polynomial[0] != 0;
        }

        private static bool IsIncorrectCoef(Dictionary<uint, int> polynomial)
        {
            return polynomial.Keys.Max() == 0 && polynomial[0] != 0;
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Polynomial result = (Polynomial)left.Clone();

            foreach (uint key in right._coefficients.Keys)
            {
                if (!left._coefficients.ContainsKey(key))
                {
                    result._coefficients.Add(key, right._coefficients[key]);
                }
                else
                {
                    result._coefficients[key] += right._coefficients[key]; 
                }
            }

            NormalizeDictionary(result._coefficients);

            return result;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Polynomial result = (Polynomial)left.Clone();

            foreach (uint key in right._coefficients.Keys)
            {
                if (!left._coefficients.ContainsKey(key))
                {
                    result._coefficients.Add(key, right._coefficients[key] * (-1));
                }
                else
                {
                    result._coefficients[key] -= right._coefficients[key];
                }
            }

            NormalizeDictionary(result._coefficients);

            return result;
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Dictionary<uint, int> result = new Dictionary<uint, int>();

            foreach (uint leftKey in left._coefficients.Keys)
            {
                foreach (uint rightKey in right._coefficients.Keys)
                {
                    uint degree = leftKey + rightKey;
                    if (!result.ContainsKey(degree))
                    {
                        result.Add(degree, left._coefficients[leftKey] * right._coefficients[rightKey]);
                    }
                    else
                    {
                        result[degree] += left._coefficients[leftKey] * right._coefficients[rightKey];
                    }
                }
            }

            return new Polynomial(result);
        }

        public static Polynomial IncreaseDegree(Polynomial polynomial, uint newDegree)
        {
            if (newDegree <= polynomial.Degree) return null;

            uint difference = newDegree - polynomial.Degree;
            Dictionary<uint, int> coefForIncPol = new Dictionary<uint, int>
            {
                { difference, 1 }
            };
            Polynomial polynomialForIncrease = new Polynomial(coefForIncPol);

            return polynomial * polynomialForIncrease;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial))
                return false;

            Polynomial polynomial = obj as Polynomial;

            if (Degree != polynomial.Degree)
                return false;

            return _coefficients.SequenceEqual(polynomial._coefficients);
        }

        public override int GetHashCode()
        {
            int hash = 27;

            foreach (uint key in _coefficients.Keys)
            {
                hash = hash * 31 + _coefficients[key];
            }

            return hash;
        }

        public override string ToString()
        {
            if (Degree == 0 && _coefficients[0] == 0)
            {
                return "0 = 0";
            }

            StringBuilder str = new StringBuilder();

            for (int i = (int)Degree; i >= 0; i--)
            {
                if (_coefficients.ContainsKey((uint)i))
                {
                    if (i != Degree)
                    {
                        str.Append(" + ");
                    }

                    if (_coefficients[(uint)i] != 0)
                    {
                        if (_coefficients[(uint)i] != 1)
                        {
                            str.AppendFormat("{0}", _coefficients[(uint)i]);
                        }
                        else if (i == 0)
                        {
                            str.AppendFormat("{0}", _coefficients[(uint)i]);
                        }

                        if (i != 0)
                        {
                            str.Append("x");
                            if (i != 1)
                                str.AppendFormat("^{0}", i);
                        }
                    }
                }
            }
            
            str.Append(" = 0");

            return str.ToString();
        }
           
        public object Clone()
        {
            return new Polynomial(_coefficients.ToDictionary(entry => entry.Key,
                                               entry => entry.Value));
        }

        private static void NormalizeDictionary(Dictionary<uint, int> dictionary)
        {
            foreach (var item in dictionary.Where(kvp => kvp.Value == 0).ToList())
            {
                dictionary.Remove(item.Key);
            }

            if (dictionary.Count == 0)
            {
                dictionary.Add(0, 0);
            }
        }
    }
}
