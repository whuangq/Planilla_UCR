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

        public async Task AddPayment(Payment newPayment) 
        { 
            await _paymentRepository.AddPayment(newPayment);
        }

        public async Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            return await _paymentRepository.GetEmployeeLastPayment(employeeEmail, employerEmail, projectName);
        }

        public async Task<IList<Payment>> GetProjectPayments(Payment payment) 
        { 
            return await _paymentRepository.GetProjectPayments(payment);
        }
    }
}