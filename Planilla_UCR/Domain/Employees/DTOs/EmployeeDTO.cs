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
        public String Email { get; }
        public String Name { get; }
        public String LastName1 { get; }
        public String LastName2 { get; }
        public int ID { get; }
        public String BankAccount { get; }
        public String Adress { get; }
        public String PhoneNumber { get; }

        public EmployeesDTO(String email, String name, String lastName1, String lastName2, int id, String bankAccount, String adress, String phoneNumber)
        {
            Email = email;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            ID = id;
            BankAccount = bankAccount;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }
    }
}
