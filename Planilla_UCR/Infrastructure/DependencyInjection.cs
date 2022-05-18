using Domain.Core.Repositories;
using Domain.Subscriptions.Repositories;
using Infrastructure.Subscriptions;
using Infrastructure.Subscriptions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SubscriptionDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            return services;
        }
    }
}
