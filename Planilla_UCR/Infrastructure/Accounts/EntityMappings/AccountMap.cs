using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Accounts;
using Domain.Accounts.Entities;
using Domain.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Accounts.EntityMappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(p => p.Email);

            builder.Property(p => p.Password)
                   .IsRequired();
        }

    }
}
