using Domain.Persons.DTOs;
using Domain.Persons.Entities;

using Domain.Employers.DTOs;
using Domain.Employers.Entities;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employers.Repositories
{
    public interface IEmployerRepository
    {
        Task CreateEmployerAsync(String email);
        Task<IEnumerable<EmployersDTO>> GetAllAsync();
    }
}
