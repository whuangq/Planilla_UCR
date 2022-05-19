using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employers.DTOs
{
    public class EmployersDTO
    {
        public String Email { get; set; }

        public EmployersDTO(String email)
        {
            Email = email;
        }
    }
}
