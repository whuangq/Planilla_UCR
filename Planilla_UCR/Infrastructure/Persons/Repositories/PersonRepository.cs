using Domain.Core.Repositories;
using Domain.Persons.DTOs;
using Domain.Persons.Entities;
using Domain.Persons.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persons.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PersonRepository(PersonDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreatePersonAsync(String email, int id, String name, String bankAccount)
        {
            Person e = new Person(email, name, id, bankAccount);
            _dbContext.Persons.Add(e);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
