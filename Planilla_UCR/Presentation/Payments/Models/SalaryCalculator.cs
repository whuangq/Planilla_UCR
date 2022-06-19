
namespace Presentation.Payments.Models
{
    public class SalaryCalculator
    {
        double SEM = 5.50;
        double IVM = 4.0;
        double PopularBankApport = 1.0;
        public SalaryCalculator()
        {

        }

        public double GetRentTax(double grossSalary)
        {
            double RentTax = 0;
            if(grossSalary <= 863000)
            {
                RentTax = 0;
            }
            else if (863000 < grossSalary && grossSalary <= 1267000)
            {
                RentTax = 10;
            }
            else if (1267000 < grossSalary && grossSalary <= 2223000)
            {
                RentTax = 15;
            }
            else if (2223000 < grossSalary && grossSalary <= 4445000)
            {
                RentTax = 20;
            }
            else if (4445000 < grossSalary)
            {
                RentTax = 25;
            }
            return RentTax;
        }

        public double GetCSSTax()
        {
            double CSSTax = SEM+IVM+PopularBankApport;
            return CSSTax;
        }

        public double getTaxPercentage(string taxName, double grossSalary)
        {
            double taxPercentage = 0;
            if (taxName == "CCSS")
            {
                taxPercentage = GetCSSTax();
            }
            else
            {
                taxPercentage = GetRentTax(grossSalary);
            }
            return taxPercentage;
        }

        public double getTaxAmount(string taxName, double grossSalary)
        {
            double taxPercentage = 0;
            if (taxName == "CCSS")
            {
                taxPercentage = grossSalary * (GetCSSTax()/ 100);
            }
            else
            {
                taxPercentage = grossSalary * (GetRentTax(grossSalary) / 100);
            }
            return taxPercentage;
        }
    }
}
