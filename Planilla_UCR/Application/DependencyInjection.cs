using Application.Projects;
using Application.Projects.Implementations;
using Application.Subscriptions;
using Application.Subscriptions.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            return services;
        }
    }
}
