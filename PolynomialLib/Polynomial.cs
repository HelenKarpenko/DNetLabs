using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLib
{
    public class Polynomial : ICloneable
    {
        public int[] Coefficients { get; set; }
        public uint Degree
        {
            get
            {
                return (uint)Coefficients.Length;
            }
        }

        public Polynomial(uint degree) : this(new int[degree])
        {
        }

        /// <summary>
        /// Create polynomial
        /// c[0]+c[1]x+c[2]x^2+...+c[n]x^n
        /// </summary>
        /// <param name="coef">Array of Coefficients: c[0]+c[1]x+c[2]x^2+...+c[n]x^n</param>
        public Polynomial(int[] coef)
        {
            Coefficients = coef;
        }

        public Polynomial(Tuple<int, uint>[] coefDictionary)
        {
            Coefficients = new int[coefDictionary.GetLength(0)];
            for (int i = 0; i < coefDictionary.GetLength(0); i++)
            {
                Coefficients[coefDictionary[i].Item2] = coefDictionary[i].Item1;
            }
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            uint coefCount = Math.Max(left.Degree, right.Degree);

            Polynomial result = new Polynomial(coefCount);

            for (int i = 0; i < coefCount; i++)
            {
                int itemFromLeft = 0;
                int itemFromRight = 0;

                if (i < left.Degree)
                    itemFromLeft = left.Coefficients[i];

                if (i < right.Degree)
                    itemFromRight = right.Coefficients[i];

                result.Coefficients[i] = itemFromLeft + itemFromRight;
            }

            return result;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            uint coefCount = Math.Max(left.Degree, right.Degree);

            Polynomial result = new Polynomial(coefCount);

            for (int i = 0; i < coefCount; i++)
            {
                int itemFromLeft = 0;
                int itemFromRight = 0;

                if (i < left.Degree)
                    itemFromLeft = left.Coefficients[i];

                if (i < right.Degree)
                    itemFromRight = right.Coefficients[i];

                result.Coefficients[i] = itemFromLeft - itemFromRight;
            }

            return result;
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (left == null)
                throw new ArgumentNullException("Left polynomial is null.");

            if (right == null)
                throw new ArgumentNullException("Right polynomial is null.");

            uint coefCount = left.Degree + right.Degree - 1;

            int[] coef = new int[coefCount];

            for (int i = 0; i < left.Degree; i++)
            {
                for (int j = 0; j < right.Degree; j++)
                {
                    coef[i + j] += left.Coefficients[i] * right.Coefficients[j];
                }
            }

            return new Polynomial(coef);
        }
        
        public Polynomial IncreaseTheDegree(uint newDegree)
        {
            if (newDegree <= Degree) return null;

            uint difference = newDegree - Degree;
            int[] coefForIncPol = new int[difference].Select(i => 1).ToArray();
            Polynomial polynomialForIncrease = new Polynomial(coefForIncPol);

            return this * polynomialForIncrease;
        }

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

            for (int i = 0; i < Degree; i++)
            {
                hash = hash * 31 + Coefficients[i];
            }
          
            return hash;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < Degree; i++)
            {
                if (Coefficients[i] != 0)
                {
                    if (Coefficients[i] != 1)
                    {
                        str.AppendFormat("{0}", Coefficients[i]);
                    }

                    int power = (int)Degree - i - 1;
                    if (power != 0)
                    {
                        str.Append("x");
                        if (power != 1)
                            str.AppendFormat("^{0}", power);
                    }

                    if (i != Coefficients.Length - 1)
                        str.AppendFormat(" + ");
                }
            }
            str.Append(" = 0\n");

            return str.ToString();
        }

        public object Clone()
        {
            int[] copyCoef = new int[Degree];
            Coefficients.CopyTo(copyCoef, 0);
            return new Polynomial(copyCoef);
        }
    }
}
