using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLib
{
    public class PolynomialException : Exception
    {
        public PolynomialException() { }

        public PolynomialException(string message) : base(message) { }
    }
}
