using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    /// <summary>
    /// Addition of Two integer numbers using Constructor
    /// </summary>
    public class Add
    {
        public int sum { get; }

        public Add(int n1, int n2)
        {
            // we can only get the value iniside constructor not set it.
            sum = n1 + n2;
        }
    }
}
