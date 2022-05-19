using Domain.Core.Repositories;
using Domain.Employers.DTOs;
using Domain.Employers.Entities;
using Domain.Employers.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<EmployersDTO>> GetAllAsync()
        {
          
            return await _dbContext.Employers.Select(t => new EmployersDTO(t.Email)).ToListAsync();
        }
    }
}
