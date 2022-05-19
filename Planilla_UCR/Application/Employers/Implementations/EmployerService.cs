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


namespace Application.Employers.Implementations
{
    internal class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task CreateEmployerAsync(String email)
        {
            await _employerRepository.CreateEmployerAsync(email);
        }

        public async Task<IEnumerable<EmployersDTO>> GetAllEmployerAsync()
        {
            return await _employerRepository.GetAllAsync();
        }

    }
}
