﻿using Domain.Persons.Repositories;
using Domain.Persons.Entities;
using System.Threading.Tasks;
using System;
using Domain.Persons.DTOs;
using Domain.Core.Repositories;
using System.Collections.Generic;

namespace Application.Persons.Implementations
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePersonAsync(Person personInfo)
        {
            await _personRepository.CreatePersonAsync(personInfo);
        }
        /*
        public async Task<Person?> GetAccountEmail(String email)
        {
           return await _personRepository.GetAccountEmail(email);
        }
        */
    }
}
