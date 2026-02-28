namespace MVCDemo.Models
{
    public class CompanyViewModel
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Department> Departments { get; set; } = new();
    }
}