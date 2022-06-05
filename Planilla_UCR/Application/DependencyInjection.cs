using Application.People;
using Application.People.Implementations;
using Application.Employees;
using Application.Employees.Implementations;
using Application.Subscriptions;
using Application.Subscriptions.Implementations;
using Application.Accounts;
using Application.Accounts.Implementations;
using Application.Employers;
using Application.Employers.Implementations;
using Application.Projects;
using Application.Projects.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Application.Authentication;
using Application.Authentication.Implementations;
using Microsoft.AspNetCore.Identity;
using Application.Authorization;
using Application.Authorization.Implementations;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEmployerService, EmployerService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationServices, AuthorizationServices>();
            return services;
        }
    }
}
