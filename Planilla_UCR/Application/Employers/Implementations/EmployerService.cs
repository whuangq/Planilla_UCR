using Domain.Employers.Repositories;
using System;
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
    }
}
