using Domain.Accounts.DTOs;
using Domain.Accounts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accounts
{
    public interface IAccountService
    {
        Task CreateAccountAsync(string email, string password);
    }
}
