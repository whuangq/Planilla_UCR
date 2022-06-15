using Domain.Subscribes.Entities;
using Infrastructure.Core;
using Infrastructure.Subscribes.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Subscribes
{
    public class SubscribeDbContext : ApplicationDbContext
    {
        public SubscribeDbContext(DbContextOptions<SubscribeDbContext> options, ILogger<SubscribeDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Subscribe> Subscribes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscribeMap());
        }
    }
}
