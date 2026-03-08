using EmployeeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Core.Repositories
{
    internal class EmployeeRepo : IEmployeeRepo
    {
        public Employee? emp;

        public void Add(Employee employee)
        {
            emp = employee;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
