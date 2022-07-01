using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task CreateProjectAsync(Project project);

        Task<IEnumerable<Project>> GetAllProjectsAsync();

        Task<IEnumerable<Project>> GetAllNameProjects(string name);

        Task<Project> GetProject(string employerEmail, string projectName);

        Task<Project> GetProject(string projectName);

        Task<IEnumerable<Project>> GetEmployerProyects(string email);

        Task<IEnumerable<Project>> GetEmployeeProyects(string email);

        public void ModifyProject(Project project, string newProjectName);

        public void DisableProject(string projectName, string employerEmail);

        public void UpdatePaymentDate(Project project);
    }
}