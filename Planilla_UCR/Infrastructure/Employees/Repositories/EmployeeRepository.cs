using Domain.Core.Repositories;
using Domain.Employees.Entities;
using Domain.Employees.Repositories;
using Domain.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public EmployeeRepository(EmployeeDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateEmployeeAsync(String email)
        {
            _dbContext.Add(new Employee(email));
            await _dbContext.SaveEntitiesAsync();
        }


        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.Select(t => new EmployeeDTO(t.Email)).ToListAsync();
        }
    }
}
