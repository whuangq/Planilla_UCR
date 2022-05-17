using Domain.Persons.Repositories;
using Domain.Persons.Entities;
using System.Threading.Tasks;

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
    }
}
