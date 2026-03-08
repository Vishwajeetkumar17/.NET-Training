using System;
using System.Collections.Generic;
using System.Text;
using EmployeeApp.Core.Models;
using EmployeeApp.Core.Repositories;

namespace EmployeeApp.Core.Services
{
    public sealed class EmployeeServices
    {
        private readonly IEmployeeRepo _repo;
        public EmployeeServices(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public Employee GetEmployeeOrThrow(int id)
        {
            if(id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive");
            var employee = _repo.GetById(id);
            if(employee is null)
            {
                throw new KeyNotFoundException($"Employee with {id} not found");
            }
            return employee;
        }
    }
}
