using System;

namespace Domain.Accounts.DTOs
{
    public class AccountsDTO
    {
        public String Email { get; set; }
        public String UserPassword { get; set; }
        public AccountsDTO(string email, string userPassword)
        {
            Email = email;
            UserPassword = userPassword;
        }
    }
}
