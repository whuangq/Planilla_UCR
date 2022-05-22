using Domain.Accounts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        Task InsertAccountData(Account accountData);

        Task<IEnumerable<Account>> CheckEmail(Account accountData);

        Task<IEnumerable<Account>> CheckPassword(Account accountData);
        Task SendEmail(string message, string receiver);
    }
}
