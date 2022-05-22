using Domain.Accounts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Accounts
{
    public interface IAccountService
    {
        Task InsertAccountData(Account accountData);
        Task<IEnumerable<Account>> CheckEmail(Account accountData);
        Task<IEnumerable<Account>> CheckPassword(Account accountData);
        Task SendEmail(string message, string receiver);
    }
}
