using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    public class DivideByOddException : Exception
    {
        public DivideByOddException()
        : base("Division by an odd number is not allowed.")
        {
        }
    }
    public class DivideByZeroInternalException : Exception
    {
        public DivideByZeroInternalException()
        : base("Internal Exception Occurred. Please contact admin.")
        {
        }
        public DivideByZeroInternalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
