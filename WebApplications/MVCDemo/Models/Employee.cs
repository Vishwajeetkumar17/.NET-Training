using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be greater than 2 characters")]
        public string Name { get; set; } = "";

        // This links the Employee to a specific Department ID
        public int DepartmentId { get; set; }

        // This is for displaying the Name in the table later
        public string? DepartmentName { get; set; }
    }
}