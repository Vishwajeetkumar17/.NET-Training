using System;

namespace UserAuthenticationProblem6
{
    /// <summary>
    /// Represents a user with authentication credentials.
    /// </summary>
    public class User
    {
        #region Properties

        // Gets or sets the user name
        public string Name { get; set; }

        // Gets or sets the password
        public string Password { get; set; }

        // Gets or sets the confirmation password
        public string ConfirmationPassword { get; set; }

        #endregion
    }

    /// <summary>
    /// Validates user password details and
    /// handles user registration workflow.
    /// </summary>
    public class Program
    {
        #region Validation Methods

        // Validates password and confirmation password
        public User ValidatePassword(string name, string password, string confirmationPassword)
        {
            if (!password.Equals(confirmationPassword, StringComparison.OrdinalIgnoreCase))
            {
                throw new PasswordMismatchException();
            }

            return new User
            {
                Name = name,
                Password = password,
                ConfirmationPassword = confirmationPassword
            };
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();

            try
            {
                p.ValidatePassword("Vishwajeet", "hello", "hello");
                Console.WriteLine("Registered Successfully");
            }
            catch (PasswordMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
