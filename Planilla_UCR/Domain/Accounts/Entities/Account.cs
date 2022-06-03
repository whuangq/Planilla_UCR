using System;

namespace Domain.Accounts.Entities
{
    public class Account
    {
        public String Email { get; set; }
        public byte[] UserPassword { get; set; }
        public bool IsAuthenticated { get; set; }
        public Account(String email, byte[] userPassword) {
            Email = email;
            UserPassword = userPassword;
            IsAuthenticated = false;
        }
    }
}
