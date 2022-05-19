using System.Threading.Tasks;

namespace Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(string email, string password);
    }
}
