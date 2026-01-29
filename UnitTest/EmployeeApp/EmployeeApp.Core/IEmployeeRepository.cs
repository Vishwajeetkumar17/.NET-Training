using EmployeeApp.Core;
using System.Collections;
using System.Collections.Generic;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
}