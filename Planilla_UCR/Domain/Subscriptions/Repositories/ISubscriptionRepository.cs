using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Subscriptions.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync();
        Task CreateSubscriptionAsync(Subscription subscription);
    }
}