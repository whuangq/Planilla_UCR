using Application.People;
using Application.People.Implementations;
using Application.Employees;
using Application.Employees.Implementations;
using Application.Subscriptions;
using Application.Subscriptions.Implementations;
using Application.Employers;
using Application.Employers.Implementations;
using Application.Projects;
using Application.Projects.Implementations;
using Application.Agreements;
using Application.Agreements.Implementations;
using Application.AgreementTypes;
using Application.AgreementTypes.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Application.Authentication;
using Application.Authentication.Implementations;
using Microsoft.AspNetCore.Identity;
using Application.Authorization;
using Application.Authorization.Implementations;
using Application.Email;
using Application.Email.Implementations;
using Application.ContextMenu;
using Application.ContextMenu.Implementations;

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
            services.AddTransient<IEmployerService, EmployerService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationServices, AuthorizationService>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IAgreementService, AgreementService>();
            services.AddTransient<IAgreementTypeService, AgreementTypeService>();
            services.AddScoped<IContextMenuService, ContextMenuService>();
            return services;
        }
    }
}
