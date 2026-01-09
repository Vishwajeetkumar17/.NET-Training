using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateCustomer
{
    // Delegate for multicast invocation
    public delegate void MyDelegate(string msg);

    /// <summary>
    /// Demonstrates multicast delegate functionality
    /// by invoking multiple methods through a single delegate.
    /// </summary>
    public class MulticastDelegate
    {
        #region Delegate Methods

        // Prints a greeting message
        static void Method1(string message) => Console.WriteLine("Hello " + message);

        // Prints a New Year greeting message
        static void Method2(string message) => Console.WriteLine("Happy New Year " + message);

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(Method1);
            myDelegate += Method2;
            myDelegate("Vishwajeet");
        }

        #endregion
    }
}
