using Domain.Core.Repositories;
using Domain.Persons.Entities;
using Domain.Persons.DTOs;
using Domain.Persons.Repositories;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public async Task CreatePersonAsync(Person personInfo)
        {
            try
            {
                _dbContext.Persons.Add(personInfo);
                await _dbContext.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repeated key error" + ex.Message);
            }   
        }

        public async Task<IEnumerable<Person?>> GetAllEmployees()
        {
            var employeeList =  await _dbContext.Persons.FromSqlRaw("EXEC GetAllEmployees").ToListAsync();
            return employeeList;
        }
    }
}
