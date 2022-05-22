using Domain.Employees.Repositories;
using Domain.Employees.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Employees.Implementations
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateEmployeeAsync(String email)
        {
            await _employeeRepository.CreateEmployeeAsync(email);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByEmail(string email)
        {
            return await _employeeRepository.GetEmployeeByEmail(email);
        }
    }
}
