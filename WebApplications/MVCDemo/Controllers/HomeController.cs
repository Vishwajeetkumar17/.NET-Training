using MVCDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // Temporary "Database"
        private static List<Employee> _employees = new List<Employee>();
        private static List<Department> _departments = new List<Department>
        {
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Payroll" }
        };

        [HttpGet]
        public IActionResult EmployeeView()
        {
            // Pass the departments to the View so the Dropdown can see them
            ViewBag.Departments = new SelectList(_departments, "Id", "Name");
            return View("../Employee/EmployeeView");
        }   

        [HttpPost]
        public IActionResult EmployeeView(Employee emp)
        {
            if (ModelState.IsValid)
            {
                // Find the name of the department chosen based on the ID
                var dept = _departments.FirstOrDefault(d => d.Id == emp.DepartmentId);
                emp.DepartmentName = dept?.Name ?? "Unknown";

                _employees.Add(emp);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_departments, "Id", "Name");
            return View("../Employee/EmployeeView", emp);
        }

        public IActionResult Index()
        {
            var model = new CompanyViewModel
            {
                Employees = _employees,
                Departments = _departments
            };

            // Pass the combined model to the view
            return View("../Employee/Index", model);
        }
    }
}