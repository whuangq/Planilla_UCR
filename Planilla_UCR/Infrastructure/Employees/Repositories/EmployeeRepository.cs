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

namespace Infrastructure.Projects.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public EmployeeRepository(ProjectDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public Task CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
