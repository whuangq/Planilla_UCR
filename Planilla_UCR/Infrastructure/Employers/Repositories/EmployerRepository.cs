using Domain.Core.Repositories;
using Domain.Employers.Entities;
using Domain.Employers.Repositories;
using System;
using System.Threading.Tasks;


namespace Infrastructure.Employers.Repositories
{
    internal class EmployerRepository : IEmployerRepository
    {
        private readonly EmployerDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public EmployerRepository(EmployerDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateEmployerAsync(String email)
        {
            _dbContext.Add(new Employer(email));
            await _dbContext.SaveEntitiesAsync();
        }
    }
}