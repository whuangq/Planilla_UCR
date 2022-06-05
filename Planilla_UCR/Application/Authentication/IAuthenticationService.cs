using System.Threading.Tasks;
using Domain.Accounts.DTOs;

namespace Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterRequestAsync(AccountsDTO accountData);
        Task<bool> SignInRequestAsync(AccountsDTO accountData, bool isPersistent);
        Task<bool> SignInInternalAsync(string token, bool isPersistent);
        string EncryptString(string data, string key);
        string Decrypt(string data, string key);
        Task SignOut();
    }
}
