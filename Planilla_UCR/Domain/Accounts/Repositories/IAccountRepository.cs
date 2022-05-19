using System.Threading.Tasks;
using Domain.Accounts.Entities;

namespace Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(Account accountInfo);
    }
}
