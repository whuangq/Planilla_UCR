using Domain.Accounts.Entities;
using Infrastructure.Core;
using Infrastructure.Accounts.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Accounts
{
    public class AccountDbContext : ApplicationDbContext
    {
        public AccountDbContext(DbContextOptions options, ILogger<AccountDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}