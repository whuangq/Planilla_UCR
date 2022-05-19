using System;


namespace Domain.Accounts.DTOs
{
    public class AccountsDTO
    {
        public String Email { get; set; }
        public String Password { get; set; }
       
        public AccountsDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
