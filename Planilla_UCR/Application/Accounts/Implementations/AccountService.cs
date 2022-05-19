using Domain.Core.Repositories;
using Domain.Accounts.DTOs;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task CreateAccountAsync(string email, string password)
        {
            await _accountRepository.CreateAccountAsync(email, password);
        }
    }
}
