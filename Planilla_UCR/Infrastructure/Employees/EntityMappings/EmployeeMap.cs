using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Employees;
using Domain.Employees.Entities;
using Domain.Projects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Employees.EntityMappings
{
    internal class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("PERSON");

            builder.HasKey(p => p.Id);

            builder.Property(P => P.Email);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.LastName1);

            builder.Property(p => p.LastName2);

            builder.Property(p => p.Ssn)
                 .IsRequired();

            builder.Property(p => p.BankAccount)
               .IsRequired();

            builder.Property(p => p.Adress);

            builder.Property(p => p.PhoneNumber);
        }
    }
}
