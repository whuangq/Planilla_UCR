using Domain.Core.Repositories;
using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using Domain.Projects.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projects.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ProjectDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProjectRepository(ProjectDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            return await _dbContext.Projects.Select(t => new ProjectDTO(t.Id, t.Project_Name, t.Publication, t.Group)).ToListAsync();
        }
    }
}
