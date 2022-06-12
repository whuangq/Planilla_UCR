using Infrastructure.People;
using Infrastructure.People.Repositories;
using Domain.People.Repositories;
using Infrastructure.Employees;
using Infrastructure.Employees.Repositories;
using Domain.Employees.Repositories;
using Domain.Subscriptions.Repositories;
using Infrastructure.Subscriptions;
using Infrastructure.Subscriptions.Repositories;
using Infrastructure.Employers.Repositories;
using Domain.Employers.Repositories;
using Infrastructure.Projects.Repositories;
using Domain.Projects.Repositories;
//  using Domain.Accounts.Repositories;
using Infrastructure.Agreements;
using Infrastructure.Agreements.Repositories;
using Domain.Agreements.Repositories;
using Infrastructure.AgreementTypes;
using Infrastructure.AgreementTypes.Repositories;
using Domain.AgreementTypes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Employers;
using Infrastructure.Projects;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Domain.Authentication.Repositories;
using Infrastructure.Authentication.Repositories;
using Domain.Authorization.Repositories;
using Infrastructure.Authorization.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString, string AuthenticationDB)
        {

            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IPersonRepository, PersonRepository>();
            
            services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<SubscriptionDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddDbContext<EmployerDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmployerRepository, EmployerRepository>();

            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddDbContext<AccountsDbContext>(options => options.UseSqlServer(AuthenticationDB), ServiceLifetime.Transient);
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AccountsDbContext>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

            services.AddDbContext<AgreementDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAgreementRepository, AgreementRepository>();

            services.AddDbContext<AgreementTypeDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAgreementTypeRepository, AgreementTypeRepository>();
            return services;
        }
    }
}
