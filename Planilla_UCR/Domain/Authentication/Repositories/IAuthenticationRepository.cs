using Domain.Accounts.DTOs;
using System.Threading.Tasks;

namespace Domain.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<bool> RegisterRequestAsync(AccountsDTO accountData);
        Task<bool> SignInRequestAsync(AccountsDTO accountData , bool isPersistent);
        Task<bool> SignInInternalAsync(string token, bool isPersistent);
        string EncryptString(string data, string key);
        string Decrypt(string data, string key);
        public Task SignOut();
    }
}
