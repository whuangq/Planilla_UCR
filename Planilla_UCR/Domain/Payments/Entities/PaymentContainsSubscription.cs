using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payments.Entities
{
    public class PaymentContainsSubscription
    {
        public string EmployeeEmail { get; set; }
        public string EmployerEmail { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SubscriptionName { get; set; }
        public PaymentContainsSubscription(string employeeEmail, string employerEmail, string projectName, DateTime startDate, DateTime endDate, string subscriptrionName)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            SubscriptionName = subscriptrionName;
        }
        public PaymentContainsSubscription()
        {
        }
    }
}
