using Domain.Core.Repositories;
using Domain.Subscriptions.DTOs;
using Domain.Subscriptions.Repositories;
using Domain.Subscriptions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<SubscriptionDTO>> GetAllAsync()
        {
            return await _dbContext.Subscriptions.Select(t => new SubscriptionDTO(t.EmployerEmail, t.NameSubscription, t.Cost, t.TypeSubscription)).ToListAsync();
        }
    }
}
