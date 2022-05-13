using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync(); 
    }
}
