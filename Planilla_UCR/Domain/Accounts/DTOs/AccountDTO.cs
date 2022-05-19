using System;

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
