using Domain.Subscriptions.DTOs;
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
    }
}