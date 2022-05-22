using System;

namespace Domain.Accounts.Entities
{
    public class Account
    {
        public String Email { get; set; }
        public String UserPassword { get; set; }

        public Account(String email, String userPassword) {
            Email = email;
            UserPassword = userPassword;
        }
    }
}
