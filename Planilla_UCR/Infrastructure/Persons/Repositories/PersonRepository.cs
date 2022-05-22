using Domain.Core.Repositories;
using Domain.Persons.Entities;
using Domain.Persons.Repositories;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using Application.Accounts;
using Infrastructure.Accounts;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        /*
        public async Task<Account?> GetAccountEmail(String email)
        {
            try
            {
                var emailUserAccount = _dbContext.Persons.FromSqlRaw("EXEC GetAccountByEmail @EmailAccount= {email}");
               
                return emailUserAccount;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Not Registered" + ex.Message);
            }
        }
        */

    }
}
