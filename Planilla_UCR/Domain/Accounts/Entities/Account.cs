using System;

namespace Domain.Accounts.Entities
{
    public class Account
    {
        public String Email { get; set; }
        public byte[] UserPassword { get; set; }
        public Account(String email, byte[] userPassword) {
            Email = email;
            UserPassword = userPassword;
        }
    }
}
