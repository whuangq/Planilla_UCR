using Domain.Persons.Repositories;
using Domain.Persons.Entities;
using Domain.Persons.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Persons.Implementations
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository employeeRepository)
        {
            _personRepository = employeeRepository;
        }

        public async Task CreatePersonAsync(Person personInfo)
        {
            await _personRepository.CreatePersonAsync(personInfo);
        }

        public async Task<IEnumerable<Person>> GetAllEmployees()
        {
            return await _personRepository.GetAllEmployees();
        }
    }
}
