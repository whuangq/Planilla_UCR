using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees.DTOs
{
    public class EmployeesDTO
    {
        public String Email { get; set; }

        public EmployeesDTO(String email)
        {
            Email = email;
        }
    }
}
