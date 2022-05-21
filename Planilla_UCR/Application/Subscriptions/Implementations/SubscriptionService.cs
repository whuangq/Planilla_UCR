using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using System.Collections.Generic;
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
            return await _subscriptionRepository.GetAllSubscriptionsAsync();
        }
        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            await _subscriptionRepository.CreateSubscriptionAsync(subscription);
        }

        public async Task<Subscription>? GetSubscription(string employerEmail, string nameSubscription)
        {
            return await _subscriptionRepository.GetSubscription(employerEmail, nameSubscription);
        }
    }
}