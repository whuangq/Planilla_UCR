using Domain.Core.Repositories;
using Domain.Projects.DTOs;
using Domain.Projects.Repositories;
using Domain.Projects.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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
            return await _dbContext.Projects.Select(t => new 
            ProjectDTO(t.EmployerEmail, t.ProjectName, 
            t.ProjectDescription, t.MaximumAmountForBenefits,
            t.MaximumBenefitAmount, t.PaymentInterval)).ToListAsync();
        }

        public async Task CreateProjectAsync(Project projectInfo)
        {
            _dbContext.Projects.Add(projectInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Project?>> GetAllNameProjects(string name)
        {
            {
                var nameList = await _dbContext.Projects.FromSqlRaw("EXEC ProjectNameCheck @name",
                    new SqlParameter("name", name)).ToListAsync();
                return nameList;
            }
        }
    }
}
