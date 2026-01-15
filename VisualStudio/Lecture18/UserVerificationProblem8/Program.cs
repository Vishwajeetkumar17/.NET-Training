using System;

namespace UserVerificationProblem8
{
    /// <summary>
    /// Represents a user with basic identity details.
    /// </summary>
    public class User
    {
        #region Properties

        // Gets or sets the user name
        public string Name { get; set; }

        // Gets or sets the phone number
        public string PhoneNumber { get; set; }

        #endregion
    }

    /// <summary>
    /// Validates user phone numbers and handles
    /// user verification workflow.
    /// </summary>
    public class Program
    {
        #region Validation Methods

        // Validates phone number and returns a user object
        public User ValidatePhoneNumber(string name, string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                throw new InvalidPhoneNumberException();
            }

            return new User { Name = name, PhoneNumber = phoneNumber };
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();

            try
            {
                p.ValidatePhoneNumber("Vishwajeet", "1234568901");
                Console.WriteLine("Correct Phone Number");
            }
            catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
