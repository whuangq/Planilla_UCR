using Domain.Core.Repositories;
using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using Domain.Projects.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Projects.Implementations
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository) 
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }
    }
}
