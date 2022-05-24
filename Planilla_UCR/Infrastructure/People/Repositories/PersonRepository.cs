using Domain.Core.Repositories;
using Domain.People.Entities;
using Domain.People.Repositories;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Infrastructure.People.Repositories
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

        public async Task<IEnumerable<Person?>> GetProjectEmployees(string projectName)
        {
            var employeeList = await _dbContext.Persons.FromSqlRaw("EXEC GetProjectEmployees @projectName",
                new SqlParameter("projectName", projectName)).ToListAsync();
            return employeeList;
        }

        public async Task<IEnumerable<Person?>> GetPersonByEmail(string email)
        {
            var peopleList = await _dbContext.Persons.FromSqlRaw("EXEC GetPersonByEmail @email",
                new SqlParameter("email", email)).ToListAsync();
            return peopleList;
        }
    }
}
