using Domain.Persons.DTOs;
using Domain.Persons.Entities;

using Domain.Employers.DTOs;
using Domain.Employers.Entities;

using Domain.Employers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Employers
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(String email);
        Task<IEnumerable<EmployersDTO>> GetAllEmployerAsync();

    }
}
