using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLib
{
    public class Polynomial : ICloneable
    {
        public Dictionary<uint, int> Coefficients { get; set; }
        public uint Degree
        {
            get
            {
                return Coefficients.Keys.Max();
            }
        }

        public Polynomial(int[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException("Сoefficient array is null.");
            }

            if (coefficients.Length == 0)
            {
                coefficients = new int[] { 0 };
            }

            Coefficients = new Dictionary<uint, int>();
            for (int i = 0; i < coefficients.Length; i++)
            {
                Coefficients.Add((uint)i, coefficients[i]);
            }

            NormalizeDictionary(Coefficients);
        }

        public Polynomial(Dictionary<uint, int> coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Сoefficient dictionary is null.");
          
            NormalizeDictionary(coefficients);

            Coefficients = coefficients;
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Polynomial result = (Polynomial)left.Clone();

            foreach (uint key in right.Coefficients.Keys)
            {
                if (!left.Coefficients.ContainsKey(key))
                {
                    result.Coefficients.Add(key, right.Coefficients[key]);
                }
                else
                {
                    result.Coefficients[key] += right.Coefficients[key]; 
                }
            }

            return result;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Polynomial result = (Polynomial)left.Clone();

            foreach (uint key in right.Coefficients.Keys)
            {
                if (!left.Coefficients.ContainsKey(key))
                {
                    result.Coefficients.Add(key, right.Coefficients[key] * (-1));
                }
                else
                {
                    result.Coefficients[key] -= right.Coefficients[key];
                }
            }

            return result;
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            Dictionary<uint, int> result = new Dictionary<uint, int>();

            foreach (uint leftKey in left.Coefficients.Keys)
            {
                foreach (uint rightKey in right.Coefficients.Keys)
                {
                    uint degree = leftKey + rightKey;
                    if (!result.ContainsKey(degree))
                    {
                        result.Add(degree, left.Coefficients[leftKey] * right.Coefficients[rightKey]);
                    }
                    else
                    {
                        result[degree] += left.Coefficients[leftKey] * right.Coefficients[rightKey];
                    }
                }
            }
            
            return new Polynomial(result);
        }

        //public Polynomial IncreaseTheDegree(uint newDegree)
        //{
        //    if (newDegree <= Degree) return null;

        //    uint difference = newDegree - Degree;
        //    int[] coefForIncPol = new int[difference].Select(i => 1).ToArray();
        //    Polynomial polynomialForIncrease = new Polynomial(coefForIncPol);

        //    return this * polynomialForIncrease;
        //}


        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial))
                return false;

            Polynomial polynomial = obj as Polynomial;

            if (Degree != polynomial.Degree)
                return false;

            return Coefficients.SequenceEqual(polynomial.Coefficients);
        }

        public override int GetHashCode()
        {
            int hash = 27;

            foreach (uint key in Coefficients.Keys)
            {
                hash = hash * 31 + Coefficients[key];
            }

            return hash;
        }

        public override string ToString()
        {
            if (Degree == 0 && Coefficients[0] == 0)
            {
                return "0 = 0";
            }

            StringBuilder str = new StringBuilder();

            for (int i = (int)Degree; i >= 0; i--)
            {
                if (Coefficients.ContainsKey((uint)i))
                {
                    if (i != Degree)
                    {
                        str.Append(" + ");
                    }

                    if (Coefficients[(uint)i] != 0)
                    {
                        if (Coefficients[(uint)i] != 1)
                        {
                            str.AppendFormat("{0}", Coefficients[(uint)i]);
                        }
                        else
                        {
                            if(i == 0)
                                str.AppendFormat("{0}", Coefficients[(uint)i]);
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
            return new Polynomial(Coefficients.ToDictionary(entry => entry.Key,
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
