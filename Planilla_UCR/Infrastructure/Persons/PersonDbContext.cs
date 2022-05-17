using Infrastructure.Persons.EntityMappings;
using Domain.Persons.Entities;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persons
{
    internal class PersonDbContext : ApplicationDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options,
                               ILogger<PersonDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Person> Persons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
    }
}
