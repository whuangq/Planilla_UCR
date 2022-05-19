﻿using Application.Persons;
using Application.Accounts;
using Application.Accounts.Implementations;
using Application.Persons;
using Application.Persons.Implementations;
using Application.Employees;
using Application.Employees.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
