using Infrastructure.Persons;
using Infrastructure.Persons.Repositories;
using Domain.Persons.Repositories;
using Infrastructure.Employees;
using Infrastructure.Employees.Repositories;
using Domain.Employees.Repositories;
using Domain.Core.Repositories;
using Domain.Subscriptions.Repositories;
using Infrastructure.Subscriptions;
using Infrastructure.Subscriptions.Repositories;
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

            services.AddDbContext<SubscriptionDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            return services;
        }
    }
}
