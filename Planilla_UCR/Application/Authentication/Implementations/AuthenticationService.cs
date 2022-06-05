using System.Threading.Tasks;
using Domain.Authentication.Repositories;
using Domain.Accounts.DTOs;

namespace Application.Authentication.Implementations
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository auth)
        {
            _authenticationRepository = auth;
        }

        public string Decrypt(string data, string key)
        {
            return _authenticationRepository.Decrypt(data, key);
        }

        public string EncryptString(string data, string key)
        {
            return _authenticationRepository.EncryptString(data, key);
        }

        public async Task<bool> RegisterRequestAsync(AccountsDTO accountData)
        {
            return await _authenticationRepository.RegisterRequestAsync(accountData);
        }

        public async Task<bool> SignInInternalAsync(string token, bool isPersistent)
        {
            return await _authenticationRepository.SignInInternalAsync(token, isPersistent);
        }

        public async Task<bool> SignInRequestAsync(AccountsDTO accountData, bool isPersistent)
        {
            return await _authenticationRepository.SignInRequestAsync(accountData, isPersistent);
        }

        public async Task SignOut()
        {
            await _authenticationRepository.SignOut();
        }
    }
}
