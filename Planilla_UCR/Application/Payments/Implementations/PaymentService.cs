using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Payments.Implementations
{
    internal class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            return _paymentRepository.GetEmployeeLastPayment(employeeEmail, employerEmail, projectName);
        }
        public Task<IEnumerable<PaymentContainsSubscription>> GetPaymentSubscriptions(Payment payment)
        {
            return _paymentRepository.GetPaymentSubscriptions(payment);
        }
    }
}