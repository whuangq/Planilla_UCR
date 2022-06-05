using Domain.Core.Repositories;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using Domain.Accounts.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

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


        public async Task InsertAccountData(AccountsDTO accountData)
        {

            System.FormattableString query = $"EXECUTE InsertDataToAccountWithPasswordEncripted @EmailAccount = {accountData.Email}, @UserPasswordToEncrypt = {accountData.UserPassword}";
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }
        

        public async Task<IEnumerable<Account?>> CheckEmail(AccountsDTO accountData)
        {
            var email = await _dbContext.Accounts.FromSqlRaw("EXEC EmailCheckLoggin @UserEmail",
            new SqlParameter("@UserEmail", accountData.Email)).ToListAsync();
            return email;
        }

        public async Task<IEnumerable<Account?>> CheckPassword(AccountsDTO accountData)
        {

            var password = await _dbContext.Accounts.FromSqlRaw("EXEC PasswordCheckLoggin @UserEmail, @UserPassword",
                new SqlParameter("@UserEmail", accountData.Email), new SqlParameter("@UserPassword", accountData.UserPassword)).ToListAsync();
            return password;

        }
    }
}
