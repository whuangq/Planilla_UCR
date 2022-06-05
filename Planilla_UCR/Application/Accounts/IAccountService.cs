using Domain.Accounts.Entities;
using Domain.Accounts.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Accounts
{
    public interface IAccountService
    {
        Task InsertAccountData(AccountsDTO accountData, string message);
        Task<IEnumerable<Account>> CheckEmail(AccountsDTO accountData);
        Task<IEnumerable<Account>> CheckPassword(AccountsDTO accountData);
    }
}
