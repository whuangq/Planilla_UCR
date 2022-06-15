using Domain.Subscribes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Subscribes
{
    public interface ISubscribeService
    {
        Task CreateSubscribeAsync(Subscribe subscription);
        Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName);
    }
}