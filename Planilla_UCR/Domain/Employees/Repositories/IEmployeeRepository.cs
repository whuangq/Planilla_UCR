using Domain.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(String email);
        Task<IEnumerable<Employee>> GetEmployeeByEmail(string email);
    }
}
