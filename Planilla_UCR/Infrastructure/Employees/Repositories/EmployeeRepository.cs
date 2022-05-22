using Domain.Core.Repositories;
using Domain.Employees.Entities;
using Domain.Employees.Repositories;
using System;
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

        public async Task CreateEmployeeAsync(String email)
        {
            _dbContext.Add(new Employee(email));
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
