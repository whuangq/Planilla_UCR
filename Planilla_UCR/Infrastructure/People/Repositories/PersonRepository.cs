using Domain.Core.Repositories;
using Domain.People.Entities;
using Domain.People.Repositories;
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
            _dbContext.Persons.Add(personInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Person?>> GetPersonByEmail(string email)
        {
            var peopleList = await _dbContext.Persons.FromSqlRaw("EXEC GetPersonByEmail @email",
                new SqlParameter("email", email)).ToListAsync();
            return peopleList;
        }

        public async Task<IEnumerable<Person?>> GetAllInfoEmployer(Person personInfo)
        {
            var employerInfo = await _dbContext.Persons.FromSqlRaw("EXEC GetInfoEmployer @EmailEmployer",
                  new SqlParameter("@EmailEmployer",personInfo.Email)).ToListAsync();
            return employerInfo;
        }

    }
}
