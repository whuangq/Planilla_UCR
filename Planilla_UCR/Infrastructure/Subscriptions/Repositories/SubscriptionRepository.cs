using Domain.Core.Repositories;
using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Subscriptions.Repositories
{
    internal class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly SubscriptionDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public SubscriptionRepository(SubscriptionDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<SubscriptionDTO>> GetAllDeductionsAsync()
        {
            return await _dbContext.Subscriptions.Select(t => new SubscriptionDTO(t.EmployerEmail, t.ProjectName, t.SubscriptionName, t.ProviderName, t.SubscriptionDescription,t.Cost, 0, 1)).ToListAsync();
        }

        public async Task<IEnumerable<SubscriptionDTO>> GetAllBenefictsAsync()
        {
            return await _dbContext.Subscriptions.Select(t => new SubscriptionDTO(t.EmployerEmail, t.ProjectName, t.SubscriptionName, t.ProviderName, t.SubscriptionDescription, t.Cost, 1, 1)).ToListAsync();
        }

        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            _dbContext.Subscriptions.Add(subscription);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.SubscriptionName == subscriptionName 
                && e.ProjectName == projectName).ToListAsync();
            Subscription subscription = null;
            if (subscriptionResult.Length() > 0)
            {
                subscription = subscriptionResult.First();
            }
            return subscription;
        }
    }
}