using Domain.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Employees
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(String email);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
    }
}
