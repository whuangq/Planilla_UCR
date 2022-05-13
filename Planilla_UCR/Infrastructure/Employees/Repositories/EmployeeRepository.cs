using Domain.Core.Repositories;
using Domain.Employees.DTOs;
using Domain.Employees.Entities;
using Domain.Employees.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateAsync(String email, int id, String name, String bankAccount)
        {
            Employee e = new Employee(email, name, id, bankAccount);
            _dbContext.Update(e);

            await _dbContext.SaveEntitiesAsync();
        }
    }
}
