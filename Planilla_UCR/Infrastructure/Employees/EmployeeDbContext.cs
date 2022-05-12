using Domain.Employees.Entities;
using Infrastructure.Core;
using Infrastructure.Employees.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Employees
{
    internal class EmployeeDbContext:ApplicationDbContext
    {
        public EmployeeDbContext(DbContextOptions options, ILogger<EmployeeDbContext> logger) : base(options, logger)
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
