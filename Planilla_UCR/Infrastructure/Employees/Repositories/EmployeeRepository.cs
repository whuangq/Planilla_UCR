using Domain.Core.Repositories;
using Domain.Employees.Entities;
using Domain.Employees.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Domain.People.Entities;

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

        public async Task<IEnumerable<Employee?>> GetEmployeeByEmail(string email)
        {
            var employeeList = await _dbContext.Employees.FromSqlRaw("EXEC GetEmployeeByEmail @email",
                new SqlParameter("email", email)).ToListAsync();
            return employeeList;
        }

        public async Task<IEnumerable<Person?>> GetAllEmployees()
        {
            var employeeList = await _dbContext.People.FromSqlRaw("EXEC GetAllEmployees").ToListAsync();
            return employeeList;
        }

        public async Task<IEnumerable<Person?>> GetProjectEmployees(string projectName)
        {
            var employeeList = await _dbContext.People.FromSqlRaw("EXEC GetProjectEmployees @projectName",
                new SqlParameter("projectName", projectName)).ToListAsync();
            return employeeList;
        }

    }
}
