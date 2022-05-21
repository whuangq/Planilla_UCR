using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Employees.DTOs;

namespace Domain.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(String email);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
    }
}
