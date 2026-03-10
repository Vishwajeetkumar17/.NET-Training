namespace MultiViewExample.Models
{
    /// <summary>
    /// DTO for creating a new user - accepts password from user input
    /// </summary>
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Password IS included for user input
    }
}
