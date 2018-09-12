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

        public Polynomial(uint degree) : this(new int[degree + 1])
        {
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
        }

        public Polynomial(Dictionary<uint, int> coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Сoefficient dictionary is null.");

            if (coefficients.Count == 0)
            {
                coefficients.Add(0, 0);
            }

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

        //public static Polynomial operator +(Polynomial left, Polynomial right)
        //{
        //    if (left == null)
        //        throw new ArgumentNullException("Left polynomial is null.");

        //    if (right == null)
        //        throw new ArgumentNullException("Right polynomial is null.");

        //    uint coefCount = Math.Max(left.Degree, right.Degree);

        //    Polynomial result = new Polynomial(coefCount);

        //    for (uint i = 0; i < coefCount; i++)
        //    {
        //        int itemFromLeft = 0;
        //        int itemFromRight = 0;

        //        if (i < left.Degree)
        //            itemFromLeft = left.Coefficients[i];

        //        if (i < right.Degree)
        //            itemFromRight = right.Coefficients[i];

        //        result.Coefficients[i] = itemFromLeft + itemFromRight;
        //    }

        //    return result;
        //}

        //public static Polynomial operator -(Polynomial left, Polynomial right)
        //{
        //    if (left == null)
        //        throw new ArgumentNullException("Left polynomial is null.");

        //    if (right == null)
        //        throw new ArgumentNullException("Right polynomial is null.");

        //    uint coefCount = Math.Max(left.Degree, right.Degree);

        //    Polynomial result = new Polynomial(coefCount);

        //    for (int i = 0; i < coefCount; i++)
        //    {
        //        int itemFromLeft = 0;
        //        int itemFromRight = 0;

        //        if (i < left.Degree)
        //            itemFromLeft = left.Coefficients[i];

        //        if (i < right.Degree)
        //            itemFromRight = right.Coefficients[i];

        //        result.Coefficients[i] = itemFromLeft - itemFromRight;
        //    }

        //    return result;
        //}

        //public static Polynomial operator *(Polynomial left, Polynomial right)
        //{
        //    if (left == null)
        //        throw new ArgumentNullException("Left polynomial is null.");

        //    if (right == null)
        //        throw new ArgumentNullException("Right polynomial is null.");

        //    uint coefCount = left.Degree + right.Degree - 1;

        //    int[] coef = new int[coefCount];

        //    for (int i = 0; i < left.Degree; i++)
        //    {
        //        for (int j = 0; j < right.Degree; j++)
        //        {
        //            coef[i + j] += left.Coefficients[i] * right.Coefficients[j];
        //        }
        //    }

        //    return new Polynomial(coef);
        //}

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
            StringBuilder str = new StringBuilder();

            for (uint i = 0; i <= Degree; i++)
            {
                if (!Coefficients.ContainsKey(i))
                    break;

                if (Coefficients[i] != 0)
                {
                    if (Coefficients[i] != 1)
                    {
                        str.AppendFormat("{0}", Coefficients[i]);
                    }

                    uint power = Degree - i;
                    if (power != 0)
                    {
                        str.Append("x");
                        if (power != 1)
                            str.AppendFormat("^{0}", power);
                    }

                    if (i != Degree)
                        str.AppendFormat(" + ");
                }
            }

            str.Append(" = 0 ");

            return str.ToString();
        }
           
        public object Clone()
        {
            return new Polynomial(Coefficients.ToDictionary(entry => entry.Key,
                                               entry => entry.Value));
        }
    }
}
