using CommonLib;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLib;

namespace MathsLib
{
    public class MathsLogin : LoginApps
    {
        public override void Login(string uName, string password)
        {
            if (LoginStatus())
            {
                Console.WriteLine($"Maths Library Login Successful. UserName is : {uName}");
            }
        }
        public override void Logout()
        {
        }
    }
}
