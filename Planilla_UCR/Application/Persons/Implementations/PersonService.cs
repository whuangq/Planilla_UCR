using Domain.Core.Repositories;
using Domain.Persons.DTOs;
using Domain.Persons.Entities;
using Domain.Persons.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task CreatePersonAsync(String email, int Ssn, String name, String bankAccount)
        {
            await _personRepository.CreatePersonAsync(email, Ssn, name, bankAccount);
        }
    }
}
