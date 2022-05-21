using Domain.Core.Repositories;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Infrastructure.Accounts.Repositories;

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

        public async Task InsertAccountData(Account accountData)
        {
            System.FormattableString query = $"EXECUTE InsertAccount @EmailAccount = {accountData.Email}, @PasswordAccount = {accountData.Password}";
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task SendEmail(string message, string receiver)
        {
            EmailSender emailSender = new();
            await emailSender.Execute(message, receiver);
        }
    }
}
