using Domain.Subscriptions.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Application.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync();
    }
}