using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllNameProjects(string name);
    }
}