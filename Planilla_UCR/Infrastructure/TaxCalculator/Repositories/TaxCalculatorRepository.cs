using Domain.TaxCalculator.Repositories;

namespace Infrastructure.TaxCalculator.Repositories
{
    public class TaxCalculatorRepository : ITaxCalculatorRepository
    {
        private readonly double SEM = 5.50;
        private readonly double IVM = 4.0;
        private readonly double POPULAR_BANK_APPORT = 1.0;

        public TaxCalculatorRepository()
        {
        }

        public double GetRentTax(double grossSalary)
        {
            double rentTax = 0;
            if (grossSalary <= 863000)
            {
                rentTax = 0;
            }
            else if (863000 < grossSalary && grossSalary <= 1267000)
            {
                rentTax = 10;
            }
            else if (1267000 < grossSalary && grossSalary <= 2223000)
            {
                rentTax = 15;
            }
            else if (2223000 < grossSalary && grossSalary <= 4445000)
            {
                rentTax = 20;
            }
            else if (4445000 < grossSalary)
            {
                rentTax = 25;
            }
            return rentTax;
        }

        public double GetCSSTax()
        {
            double cssTax = SEM + IVM + POPULAR_BANK_APPORT;
            return cssTax;
        }

        public double GetTaxPercentage(string taxName, double grossSalary)
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

        public double GetTaxAmount(string taxName, double grossSalary)
        {
            double taxPercentage;
            if (taxName == "CCSS")
            {
                taxPercentage = grossSalary * (GetCSSTax() / 100);
            }
            else
            {
                taxPercentage = grossSalary * (GetRentTax(grossSalary) / 100);
            }
            return taxPercentage;
        }
    }
}