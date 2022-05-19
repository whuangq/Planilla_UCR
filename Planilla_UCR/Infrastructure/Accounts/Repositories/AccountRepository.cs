using Domain.Core.Repositories;
using Domain.Accounts.DTOs;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Accounts.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AccountRepository(AccountDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAccountAsync(string email, string password)
        {
            Account a = new Account(email, password);
            _dbContext.Add(a);

            await _dbContext.SaveEntitiesAsync();
        }

    }
}
