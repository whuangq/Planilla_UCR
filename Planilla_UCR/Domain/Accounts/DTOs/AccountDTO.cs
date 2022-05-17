using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Accounts.DTOs
{
    public class AccountsDTO
    {
        public String Email { get; }
        public String Password { get; }
       

        public AccountsDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
