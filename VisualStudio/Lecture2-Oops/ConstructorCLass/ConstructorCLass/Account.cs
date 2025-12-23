using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorCLass
{

    /// <summary>
    /// Represents a user or entity account with an identifier and a name.
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string getAccountDetails()
        {
            return $"Base Class Details : and ID = {Id} {Environment.NewLine}";
        }
    }

    public class SalesAccount : Account
    {
        public string SalesAccDetails()
        {
            string info = string.Empty;
            info += base.getAccountDetails();
            info += $"This is Derived Sales Account.{Environment.NewLine}";
            return info;
        }
    }
    public class  PurchaseAccount : Account
    {
        public string PurchaseAccDetails()
        {
            string info = string.Empty;
            info += base.getAccountDetails();
            info += $"This is Derived Purchase Account.{Environment.NewLine}";
            return info;
        }
}
}
