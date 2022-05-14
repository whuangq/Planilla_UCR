using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Persons.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persons.Entities
{
    public class Person
    {
        public String  Email { get; set; }

        public String Name { get; set; }
        public String LastName1 { get; set; }
        public String LastName2 { get; set; }
        public int Ssn { get; set; }
        public String BankAccount { get; set; }
        public String Adress { get; set; }
        public String PhoneNumber { get; set; }

        public Person(String email, String name, String lastName1, String lastName2, int ssn, String bankAccount, String adress, String phoneNumber)
        {
            Email = email;
            Name = name;
            LastName1 = lastName1;
            LastName2 = lastName2;
            Ssn = ssn;
            BankAccount = bankAccount;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }

        public Person(String email, String name, int ssn, String bankAccount)
        {
            Email = email;
            Name = name;
            Ssn = ssn;
            BankAccount = bankAccount;
            LastName1 = "";
            LastName2 = "";
            Adress = "";
            PhoneNumber = "";
        }
    }
}
