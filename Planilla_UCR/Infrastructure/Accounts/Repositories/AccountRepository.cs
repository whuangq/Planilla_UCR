using Domain.Core.Repositories;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
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


        public async Task InsertAccountData(Account accountData)
        {

            System.FormattableString query = $"EXECUTE InsertDataToAccountWithPasswordEncripted @EmailAccount = {accountData.Email}, @UserPasswordToEncrypt = {accountData.UserPassword}";
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }


        public async Task<IEnumerable<Account?>> CheckEmail(Account accountData)
        {

            {
                var email = await _dbContext.Accounts.FromSqlRaw("EXEC EmailCheckLoggin @UserEmail",
                    new SqlParameter("@UserEmail", accountData.Email)).ToListAsync();
                return email;
            }
        }

        public async Task<IEnumerable<Account?>> CheckPassword(Account accountData)
        {

            var password = await _dbContext.Accounts.FromSqlRaw("EXEC PasswordCheckLoggin @UserEmail, @UserPassword",
                new SqlParameter("@UserEmail", accountData.Email), new SqlParameter("@UserPassword", accountData.UserPassword)).ToListAsync();
            return password;

        }

        public async Task SendEmail(string message, string receiver)
        {
            EmailSender emailSender = new();
            await emailSender.Execute(message, receiver);
        }
    }
}
