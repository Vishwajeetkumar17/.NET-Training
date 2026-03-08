using EmployeeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Core.Repositories
{
    public interface IEmployeeRepo
    {
        Employee? GetById(int id);
        IReadOnlyCollection<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
