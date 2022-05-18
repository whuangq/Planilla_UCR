using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Employees.ValueObjects;
using System;
namespace Domain.Employees.Entities

{
    public class Employee
    {
        public String Email { get; }

        public Employee(String email)
        {
            Email = email;
        }

        public Employee(String email, String name, int id, String bankAccount)
        {
            Email = email;
        }
    }
}
