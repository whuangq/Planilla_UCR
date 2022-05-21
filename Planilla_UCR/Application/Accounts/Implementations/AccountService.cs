using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using System.Threading.Tasks;

namespace Application.Accounts.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public async Task CreateAccountAsync(Account accountInfo)
        {
            await _accountRepository.CreateAccountAsync(accountInfo);
        }

        public async Task InsertAccountData(Account accountData)
        {

            await _accountRepository.InsertAccountData(accountData);
        }
    }
}
