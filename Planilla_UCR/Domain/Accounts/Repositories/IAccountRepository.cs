using Domain.Accounts.Entities;
using Domain.Accounts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        Task InsertAccountData(AccountsDTO accountData);
        Task<IEnumerable<Account>> CheckEmail(AccountsDTO accountData);
        Task<IEnumerable<Account>> CheckPassword(AccountsDTO accountData);
    }
}
