using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Payments.Implementations
{
    public class PaymentService : IPaymentService
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

        public async Task<IEnumerable<Payment>> GetEmployeePayments(string email)
        {
            return await _paymentRepository.GetEmployeePayments(email);
        }

        public async Task<IEnumerable<Payment>> GetLastEmployeePayments(string email)
        {
            return await _paymentRepository.GetLastEmployeePayments(email);
        }

        public async Task<IEnumerable<Payment>> GetEmployerPayments(string email)
        {
            return await _paymentRepository.GetEmployerPayments(email);
        }

        public async Task<IEnumerable<Payment>> GetLastEmployerPayments(string email)
        {
            return await _paymentRepository.GetLastEmployerPayments(email);
        }

        public async Task<IEnumerable<Payment>> GetEmployeeLatestPayments(string employeeEmail)
        {
            return await _paymentRepository.GetEmployeeLatestPayments(employeeEmail);
        }


        public async Task<IList<Payment>> GetAllPaymentsStartAndEndDates(string employerEmail, string projectName)
        {
            return await _paymentRepository.GetAllPaymentsStartAndEndDates(employerEmail, projectName);
        }
    }
}