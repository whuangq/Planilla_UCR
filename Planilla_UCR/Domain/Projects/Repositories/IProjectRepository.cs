using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Projects.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllNameProjects(string name);
        Task<IEnumerable<Project>> GetEmployerProyects(string email);
        Task<Project> GetProject(string employerEmail, string projectName);
    }
}