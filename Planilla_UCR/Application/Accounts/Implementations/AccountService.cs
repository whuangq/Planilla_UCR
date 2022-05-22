using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Application.Accounts.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }

        public async Task InsertAccountData(Account accountData)
        {

            await _accountRepository.InsertAccountData(accountData);
        }

        public async Task<IEnumerable<Account>>CheckEmail(Account accountData)
        {

           return await _accountRepository.CheckEmail(accountData);
        }

        public async Task<IEnumerable<Account>>CheckPassword(Account accountData)
        {

           return await _accountRepository.CheckPassword(accountData);
        }


        public async Task SendEmail(string message, string receiver)
        {
            await _accountRepository.SendEmail(message, receiver);
        }
    }
}
