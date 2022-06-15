using Domain.Subscribes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Subscribes.Repositories
{
    public interface ISubscribeRepository
    {
        Task CreateSubscribeAsync(Subscribe subscription);
        Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName);
    }
}
