using Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Payments.EntityMappings
{
    public class PaymentContainsSubscriptionMap : IEntityTypeConfiguration<PaymentContainsSubscription>
    {
        public void Configure(EntityTypeBuilder<PaymentContainsSubscription> builder)
        {
            builder.ToTable("PaymentContainsSubscription");

            builder.HasKey(p => new { p.EmployeeEmail, p.EmployerEmail, p.ProjectName, p.StartDate, p.EndDate , p.SubscriptionName });
        }
    }
}
