using Domain.Employees.Repositories;
using System;
using System.Threading.Tasks;

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
    }
}
