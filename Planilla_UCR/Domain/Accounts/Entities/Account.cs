using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Accounts.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
        public Account(String email)
        {
            Email= email;
        }

        public Account(String emil, String password)
        {
            Email = email;
            Password = password;
        }
        */
    }
}
