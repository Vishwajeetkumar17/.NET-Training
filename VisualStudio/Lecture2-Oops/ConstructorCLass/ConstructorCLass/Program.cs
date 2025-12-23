using ConstructorCLass;
using System;

namespace ConstrutorClass;

/// <summary>
/// Leaning about Contructor and its different overloading properties
/// </summary>
public class Program
{
    static void Main()
    {
        #region One
        //One p = new One();  // This line would cause a compilation error because the default constructor is private.

        //try
        //{
        //    One p1 = new One(-1);
        //}
        //catch(Exception ex)
        //{
        //    Console.WriteLine($"Exception caught: {ex.Message}");
        //}

        //try
        //{
        //    One p2 = new One(2, "A Idiot");
        //}
        //catch(Exception ex)
        //{
        //    Console.WriteLine($"Exception caught: {ex.Message}");
        //}
        //One program = new One(1, "Sample Program", "This is a sample requirement.");
        #endregion

        #region Add
        //Console.WriteLine("Enter two numbers to add:");
        //int num1 = int.Parse(Console.ReadLine());
        //int num2 = int.Parse(Console.ReadLine());

        //Add add = new Add(num1, num2);
        //Console.WriteLine($"sum of {num1} + {num2} = {add.sum}");
        #endregion

        #region LogHistory
        //LogHistory lh = new LogHistory(1, "A", "Required");
        #endregion

        #region ClassField
        //ClassField cf = new ClassField();
        //cf.Id = 10;
        //string output = cf.displayEmpDetails();
        //Console.WriteLine(output);
        #endregion

        #region Employee
        //Employee emp = new Employee() { Id = -2, Name = "", Rank = 30 };

        //Console.WriteLine("Error: " + emp.errorMessage);
        #endregion

        #region Account
        //Account sa = new Account() { Id = 101, Name = "Account" };
        //Console.WriteLine(sa.getAccountDetails());

        //SalesAccount salesAccount = new SalesAccount() { Id = 102, Name = "Sales Account" };
        //Console.WriteLine(salesAccount.SalesAccDetails());

        //PurchaseAccount purchaseAccount = new PurchaseAccount() { Id = 103, Name = "Purchase Account" };
        //Console.WriteLine(purchaseAccount.PurchaseAccDetails());
        #endregion

        Father f = new Father();
        Son s = new Son();
        Console.WriteLine("Father Interest On: " + f.InterestOn());
        Console.WriteLine("Son Interest On: " + s.InterestOn());
    }
}