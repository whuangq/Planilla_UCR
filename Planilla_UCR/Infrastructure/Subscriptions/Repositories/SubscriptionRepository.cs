using Domain.Core.Repositories;
using Domain.Subscriptions.Entities;
using Domain.Subscriptions.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Subscription>> GetAllDeductionsAsync()
        {
            return await _dbContext.Subscriptions.FromSqlRaw("EXEC GetAllDeductions").ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllBenefictsAsync()
        {
            return await _dbContext.Subscriptions.FromSqlRaw("EXEC GetAllBenefits").ToListAsync();
        }

        public async Task CreateSubscriptionAsync(Subscription subscription)
        {
            _dbContext.Subscriptions.Add(subscription);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.SubscriptionName == subscriptionName 
                && e.ProjectName == projectName).ToListAsync();
            Subscription subscription = null;
            if (subscriptionResult.Length() > 0)
            {
                subscription = subscriptionResult.First();
            }
            return subscription;
        }

        public async Task<IEnumerable<Subscription>> GetDeductionsByProject(string employerEmail, string projectName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName 
                && e.TypeSubscription == 0 && e.IsEnabled == 1).ToListAsync();
            return subscriptionResult;
        }

        public async Task<IEnumerable<Subscription>> GetBenefitsByProject(string employerEmail, string projectName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName
                && e.TypeSubscription == 1 && e.IsEnabled == 1).ToListAsync();
            return subscriptionResult;
        }

        public bool ModifySubscription(Subscription subscription, string newName)
        {
            var Transaction = new SqlParameter("Transaction", 0);
            Transaction.Direction = System.Data.ParameterDirection.Output;
            System.FormattableString query = ($@"EXECUTE ModifySubscription 
                @EmployerEmail = {subscription.EmployerEmail}, @ProjectName = {subscription.ProjectName},
                @SubscriptionName = {subscription.SubscriptionName},
                @NewSubscriptionName = {newName}, @ProviderName = {subscription.ProviderName},
                @SubscriptionDescription = {subscription.SubscriptionDescription}, @Cost = {subscription.Cost},
                @TypeSubscription = {subscription.TypeSubscription}, @IsEnabled = {subscription.IsEnabled},
                @Transaction = {Transaction} OUT");
            _dbContext.Database.ExecuteSqlInterpolated(query);
            if (Convert.ToInt32(Transaction.Value) == 1) {
                return true;
            }
            else
            return false;
        }
    }
}