using Domain.Core.Repositories;
using Infrastructure.Accounts;
using Infrastructure.Accounts.Repositories;
using Domain.Accounts.Repositories;
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
            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
