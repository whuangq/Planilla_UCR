using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Projects.Repositories
{
    public interface IProjectRepository
    {
        Task CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllNameProjects(string name);
    }
}