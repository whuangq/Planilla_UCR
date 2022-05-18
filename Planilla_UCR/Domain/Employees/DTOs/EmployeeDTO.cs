using System;

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
