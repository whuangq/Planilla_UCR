using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Subscriptions.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionDTO>> GetAllDeductionsAsync();
        Task<IEnumerable<SubscriptionDTO>> GetAllBenefictsAsync();
        Task CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName);
    }
}