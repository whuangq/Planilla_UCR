using Domain.Payments.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Payments.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName);
        Task<IEnumerable<PaymentContainsSubscription?>> GetPaymentSubscriptions(Payment payment);
    }
}
