using Domain.Subscriptions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Subscriptions.EntityMappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");

            builder.HasKey(p => new { p.EmployerEmail, p.NameSubscription});

            builder.Property(p => p.ProviderName)
                .IsRequired();

            builder.Property(p => p.SubscriptionDescription)
                .IsRequired();

            builder.Property(p => p.Cost)
                 .IsRequired();

            builder.Property(p => p.TypeSubscription)
                   .IsRequired();
        }

    }
}
