using Domain.Core.Repositories;
using Domain.Employees.DTOs;
using Domain.Employees.Entities;
using Domain.Employees.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task CreateEmployeeAsync(String email, int id, String name, String bankAccount)
        {
            await _employeeRepository.CreateAsync(email, id, name, bankAccount);
        }
    }
}
