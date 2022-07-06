using System.Collections.Generic;
using Domain.Subscriptions.Entities;

namespace Domain.PaymentCalculator.Repositories
{
    public interface IPaymentCalculatorRepository
    {
        public double GetFullTimeSalary(double mountPerHour, int workedDay);
        public double GetPartTimeSalary(double mountPerHour, int workedDay);
        public double GetSalaryPerHours(double mountPerHour, double workedHours);
        public IList<Subscription> ApplyDeductions(double netSalary, IList<Subscription> deductions);
        public double DeductionsCost(IList<Subscription> deductions);
    }
}
