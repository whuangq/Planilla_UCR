using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Persons;
using Domain.Persons.Entities;
using Domain.Persons.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persons.EntityMappings
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                   .IsRequired();

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
