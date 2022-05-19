using Infrastructure.Persons;
using Infrastructure.Persons.Repositories;
using Domain.Persons.Repositories;

using Infrastructure.Employees;
using Infrastructure.Employees.Repositories;
using Domain.Employees.Repositories;

using Infrastructure.Employers;
using Infrastructure.Employers.Repositories;
using Domain.Employers.Repositories;

using Domain.Core.Repositories;
using Infrastructure.Accounts;
using Infrastructure.Accounts.Repositories;
using Domain.Accounts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<EmployerDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmployerRepository, EmployerRepository>();

            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
