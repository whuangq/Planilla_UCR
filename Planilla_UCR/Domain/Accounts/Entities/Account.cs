using System;

namespace Domain.Accounts.Entities
{
    public class Account
    {
        public String Email { get; }
        public String Password { get; }
    

        public Account(String email, String password) {
            Email = email;
            Password = password;
        }
    }
}
