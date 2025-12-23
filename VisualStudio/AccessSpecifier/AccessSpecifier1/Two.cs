using System;
using System.Collections.Generic;
using System.Text;

namespace AccessSpecifier1
{

    /// <summary>
    /// Test1 is not Accessible in this cClass as it is Private to Program Class
    /// Private are Accessible only within the Same Class
    /// </summary>
    internal class Two : Program
    {
        static void Main()
        {
            Two t = new Two();
            t.Test2(); t.Test3(); t.Test4(); t.Test5();
        }
    }
}
