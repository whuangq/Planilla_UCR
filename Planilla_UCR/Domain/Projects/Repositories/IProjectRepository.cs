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
        Task<IEnumerable<Project>> GetEmployeeProyects(string email);
        Task<Project> GetProject(string employerEmail, string projectName);
        Task<Project> GetProject(string projectName);
        public void ModifyProject(Project project, string newProjectName);
        public void DisableProject(string projectName, string employerEmail);
        public void UpdatePaymentDate(Project project);
    }
}