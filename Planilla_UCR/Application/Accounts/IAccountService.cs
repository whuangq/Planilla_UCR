using Domain.Accounts.Entities;
using System.Threading.Tasks;

namespace Application.Accounts
{
    public interface IAccountService
    {
        Task CreateAccountAsync(Account accountInfo);
        Task InsertAccountData(Account accountData);
    }
}
