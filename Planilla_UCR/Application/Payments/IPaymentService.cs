using Domain.Payments.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Payments
{
    public interface IPaymentService
    {
        Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName);
        Task<IEnumerable<PaymentContainsSubscription?>> GetPaymentSubscriptions(Payment payment);
    }
}