using Domain.Subscriptions.Entities;
using Infrastructure.Core;
using Infrastructure.Subscriptions.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Subscriptions
{
    public class SubscriptionDbContext : ApplicationDbContext
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options, ILogger<SubscriptionDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Subscription> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscriptionMap());
        }
    }
}
