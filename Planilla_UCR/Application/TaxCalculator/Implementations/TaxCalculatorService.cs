using Domain.TaxCalculator.Repositories;

namespace Application.TaxCalculator.Implementations
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxCalculatorRepository _taxCalculatorRepository;

        public TaxCalculatorService(ITaxCalculatorRepository taxCalculatorRepository)
        {
            _taxCalculatorRepository = taxCalculatorRepository;
        }

        public double GetCSSTax()
        {
           return _taxCalculatorRepository.GetCSSTax();
        }

        public double GetRentTax(double grossSalary)
        {
            return _taxCalculatorRepository.GetRentTax(grossSalary);
        }

        public double GetTaxAmount(string taxName, double grossSalary)
        {
            return _taxCalculatorRepository.GetTaxAmount(taxName, grossSalary);
        }

        public double GetTaxPercentage(string taxName, double grossSalary)
        {
            return _taxCalculatorRepository.GetTaxPercentage(taxName, grossSalary);
        }
    }
}
