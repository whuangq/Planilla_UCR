using Domain.Core.Repositories;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using System;
using System.Diagnostics;
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

        public async Task CreateAccountAsync(Account accountInfo)
        {
            try
            {
                _dbContext.Accounts.Add(accountInfo);
                await _dbContext.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repeated key error" + ex.Message);
            } 
        }
    }
}
