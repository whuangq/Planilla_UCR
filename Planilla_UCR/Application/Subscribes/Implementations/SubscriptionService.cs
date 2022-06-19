using Domain.Subscribes.Entities;
using Domain.Subscribes.Repositories;
using Domain.Subscriptions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Subscribes.Implementations
{
    internal class SubscribeService : ISubscribeService
    {
        private readonly ISubscribeRepository _subscribeRepository;

        public SubscribeService(ISubscribeRepository subscribeRepository)
        {
            _subscribeRepository = subscribeRepository;
        }

        public async Task CreateSubscribeAsync(Subscribe subscription)
        {
            await _subscribeRepository.CreateSubscribeAsync(subscription);
        }

        public async Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName)
        {
            return await _subscribeRepository.GetEmployeesBySubscription(employerEmail, projectName, subscriptionName);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionCostsByDate(Subscribe searchSubscription)
        {
            return await _subscribeRepository.GetSubscriptionCostsByDate(searchSubscription);
        }
    }
}