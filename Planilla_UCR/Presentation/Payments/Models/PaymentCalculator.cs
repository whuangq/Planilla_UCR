using System;
namespace Presentation.Payments.Models
{
    public class PaymentCalculator
    {
        double FullTimeHours = 8.0;
        double PartTimeHours = 4.0;
        public PaymentCalculator()
        {

        }

        public double GetFullTimeSalary(double mountPerHour, int workedDay)
        {
            return (FullTimeHours * Convert.ToDouble(workedDay)) * mountPerHour;
        }

        public double GetPartTimeSalary(double mountPerHour, int workedDay)
        {
            return (PartTimeHours * Convert.ToDouble(workedDay)) * mountPerHour;
        }

        public double GetSalaryPerHours(double mountPerHour, double workedHours)
        { 
            return mountPerHour * workedHours;
        }
    }
}
