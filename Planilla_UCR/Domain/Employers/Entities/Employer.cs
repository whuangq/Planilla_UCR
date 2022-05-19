using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Employers.Entities
{
    public class Employer
    {
        public String Email { get; }

        public Employer(String email)
        {
            Email = email;
        }

        public Employer(String email, String name, int id, String bankAccount)
        {
            Email = email;
        }
    }
}
