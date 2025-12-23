using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{
    public class Father
    {
        public virtual string InterestOn()
        {
            return "I like to play Cricket";
        }
    }

    public class Son : Father
    {
        public override string InterestOn()
        {
            return "I like to play Football";
        }
    }
}
