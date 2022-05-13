using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Repositories;


namespace Domain.Projects.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
    }
}
