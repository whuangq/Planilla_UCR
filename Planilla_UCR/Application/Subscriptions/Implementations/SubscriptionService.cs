using Domain.Core.Repositories;
using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Subscriptions.Implementations
{
    internal class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync()
        {
            return await _subscriptionRepository.GetAllAsync();
        }

        public async Task CreateSubscriptionAsync(String employerEmail, String nameSubscription, int cost, int type)
        {
            await _subscriptionRepository.CreateSubscriptionAsync(employerEmail, nameSubscription, cost, type);
        }
    }
}