using Domain.Core.Repositories;
using Domain.Employees.DTOs;
using Domain.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees.Repositories
{
    public interface IProjectRepository : IRepository<Employee>
    {
        Task CreateEmployee();
    }
}
