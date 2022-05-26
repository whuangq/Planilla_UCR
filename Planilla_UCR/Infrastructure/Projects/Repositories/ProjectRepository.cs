using Domain.Core.Repositories;
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
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects.Select(t => new
            Project(t.EmployerEmail, t.ProjectName,
            t.ProjectDescription, t.MaximumAmountForBenefits,
            t.MaximumBenefitAmount, t.PaymentInterval)).ToListAsync();
        }

        public async Task<Project> GetProject(string employerEmail, string projectName)
        {
            IList<Project> projectResult = await _dbContext.Projects.Where
                (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName).ToListAsync();
            Project project = null;
            if (projectResult.Length() > 0)
            {
                project = projectResult.First();
            }
            return project;
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

        public async Task<IEnumerable<Project>> GetEmployerProyects(string email) {
            IList<Project> projectsResult = await _dbContext.Projects.Where
                (e => e.EmployerEmail == email).ToListAsync();
            return projectsResult;
        }
    }
}