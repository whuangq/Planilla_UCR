using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Employees.Entities;

namespace Application.Employees
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(String email);

        Task<IEnumerable<Employee>> GetEmployeeByEmail(string email);
    }
}
