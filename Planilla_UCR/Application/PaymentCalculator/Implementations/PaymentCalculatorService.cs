using Domain.PaymentCalculator.Repositories;
using System.Collections.Generic;
using Domain.Subscriptions.Entities;

namespace Application.PaymentCalculator.Implementations
{
    public class PaymentCalculatorService : IPaymentCalculatorService
    {
        private readonly IPaymentCalculatorRepository _paymentCalculatorRepository;

        public PaymentCalculatorService(IPaymentCalculatorRepository paymentCalculatorRepository)
        {
            _paymentCalculatorRepository = paymentCalculatorRepository;
        }
        public double GetFullTimeSalary(double mountPerHour, int workedDay) 
        { 
            return _paymentCalculatorRepository.GetFullTimeSalary(mountPerHour, workedDay);
        }
        public double GetPartTimeSalary(double mountPerHour, int workedDay) 
        {
            return _paymentCalculatorRepository.GetPartTimeSalary(mountPerHour, workedDay);
        }
        public double GetSalaryPerHours(double mountPerHour, double workedHours) 
        {
            return _paymentCalculatorRepository.GetSalaryPerHours(mountPerHour, workedHours);
        }
        public IList<Subscription> ApplyDeductions(double netSalary, IList<Subscription> deductions) 
        { 
            return _paymentCalculatorRepository.ApplyDeductions(netSalary, deductions);
        }
        public double DeductionsCost(IList<Subscription> deductions) 
        { 
            return _paymentCalculatorRepository.DeductionsCost(deductions);
        }
    }
}
