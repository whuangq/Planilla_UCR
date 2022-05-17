using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Subscriptions;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Subscriptions.EntityMappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");

            builder.HasKey(p => new { p.EmployerEmail, p.NameSubscription});

            builder.Property(p => p.Cost)
                 .IsRequired();

            builder.Property(p => p.TypeSubscription)
                   .IsRequired();
        }

    }
}
