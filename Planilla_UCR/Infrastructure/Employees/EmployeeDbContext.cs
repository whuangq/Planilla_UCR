using Domain.Employees.Entities;
using Infrastructure.Core;
using Infrastructure.Employees.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Employees
{
    internal class EmployeeDbContext : ApplicationDbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, ILogger<EmployeeDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeMap());
        }
    }
}
