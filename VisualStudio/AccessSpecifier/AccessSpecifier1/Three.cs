using System;
using System.Collections.Generic;
using System.Text;

namespace AccessSpecifier1
{

    /// <summary>
    /// Test1 and Test3 are not Accessible in this cClass as Test1 is Private to Program Class and Test3 is Protected to Program Class
    /// Protected are Accessible only in Derived/Child Classes
    /// </summary>
    internal class Three
    {
        static void Main()
        {
            Program p = new Program();
            p.Test2(); p.Test4(); p.Test5();
        }
    }
}
