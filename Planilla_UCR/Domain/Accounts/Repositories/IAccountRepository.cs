using Domain.Core.Repositories;
using Domain.Accounts.DTOs;
using Domain.Accounts.Entities;
using Domain.Accounts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Accounts.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(Account accountInfo);
        Task InsertAccountData(Account accountData);
    }
}
