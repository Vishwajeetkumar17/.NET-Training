using System;
using System.Collections.Generic;
using System.Text;
using CommonLib;

namespace ScienceLib
{
    public class SciLogin : LoginApps
    {
        public override void Login(string uName, string password)
        {
            if (LoginStatus())
            {
                Console.WriteLine($"Science Library Login Successful. UserName is : {uName}");
            }

        }
        public override void Logout()
        {
        }
    }
}
