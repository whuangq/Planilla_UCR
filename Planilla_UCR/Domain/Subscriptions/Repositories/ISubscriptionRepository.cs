using Domain.Subscriptions.DTOs;
using Domain.Core.Repositories;
using Domain.Subscriptions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subscriptions.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionDTO>> GetAllAsync();
    }
}