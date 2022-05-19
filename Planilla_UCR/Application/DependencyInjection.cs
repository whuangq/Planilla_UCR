﻿using Application.Persons;
using Application.Persons.Implementations;
using Application.Employees;
using Application.Employees.Implementations;
using Application.Accounts;
using Application.Accounts.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IAccountService, AccountService>();
            return services;
        }
    }
}
