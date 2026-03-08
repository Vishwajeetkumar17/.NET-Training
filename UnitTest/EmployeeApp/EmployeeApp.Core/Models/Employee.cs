using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
