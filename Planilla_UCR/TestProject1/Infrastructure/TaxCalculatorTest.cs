using FluentAssertions;
using Xunit;
using Infrastructure.TaxCalculator.Repositories;

namespace Tests.Infrastructure
{
    public class TaxCalculatorTest
    {
        int _grossSalary = 863000;
        string _taxName = "CCSS";
        double _rentTax = 0;
        double _ccssTax = 10.5;
        double _taxPercentage = 10.5;
        double _taxAmount = 90615;

        [Fact]
        public void GetPaymentTaxes()
        {
            //arrange
            var taxCalculatorService = new TaxCalculatorRepository();

            //act
            var rentTaxt = taxCalculatorService.GetRentTax(_grossSalary);
            var ccsTax = taxCalculatorService.GetCSSTax(); 
            var taxPercentaje = taxCalculatorService.GetTaxPercentage(_taxName, _grossSalary);
            var taxAmount = taxCalculatorService.GetTaxAmount(_taxName, _grossSalary);

            //assert
            rentTaxt.Should().Be(_rentTax);
            ccsTax.Should().Be(_ccssTax);
            taxPercentaje.Should().Be(_taxPercentage);  
            taxAmount.Should().Be(_taxAmount);
        }
    }
}
