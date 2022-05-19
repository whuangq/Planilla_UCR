using System;

namespace Domain.Accounts.Entities
{
    public class Account
    {
        public String Email { get; set; }
        public String Password { get; set; }
    

        public Account(String email, String password) {
            Email = email;
            Password = password;
        }
    }
}
