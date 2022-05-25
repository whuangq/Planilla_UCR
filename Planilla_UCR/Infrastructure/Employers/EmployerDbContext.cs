using Domain.Employers.Entities;
using Infrastructure.Core;
using Infrastructure.Employers.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Employers
{
    internal class EmployerDbContext : ApplicationDbContext
    {
        public EmployerDbContext(DbContextOptions<EmployerDbContext> options, ILogger<EmployerDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Employer> Employers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployerMap());
        }
    }
}