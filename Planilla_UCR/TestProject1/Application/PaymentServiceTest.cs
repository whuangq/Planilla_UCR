using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Payments.Implementations;
using Moq;
using Xunit;
using Domain.Payments.Repositories;
using Domain.Payments.Entities;
using LanguageExt;

namespace Tests.Application
{
    public class PaymentServiceTest
    {
        List<Payment> paymentsList = new List<Payment>
        {
            new Payment("leonel@ucr.ac.cr", "Proyecto 1", "mau@ucr.ac.cr", 86000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(15)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 2", "mau@ucr.ac.cr", 153600, DateTime.Now.AddDays(1),DateTime.Now.AddDays(25)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 3", "mau@ucr.ac.cr", 16000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(3)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 4", "mau@ucr.ac.cr", 75000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(14)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 5", "mau@ucr.ac.cr", 86000, DateTime.Now.AddDays(1),DateTime.Now.AddDays(15)),
            new Payment("leonel@ucr.ac.cr", "Proyecto 6", "mau@ucr.ac.cr", 186000, DateTime.Now.AddDays(1), DateTime.Now.AddDays(28)),
        };
        
        private String _employerEmail = "leonel@ucr.ac.cr";

        [Fact]
        public async Task GetEmployerPayments()
        {

            //arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);
            mockPaymentRepository.Setup(repo => repo.GetEmployerPayments("leonel@ucr.ac.cr")).ReturnsAsync(paymentsList.Where(
                e => e.EmployerEmail == _employerEmail));

            //act
            var employerPaymentTest = paymentService.GetEmployerPayments(_employerEmail);

            //assert
            mockPaymentRepository.Verify(repo => repo.GetEmployerPayments(_employerEmail), Times.Once);
            employerPaymentTest.Count().Should().Equals(5);
        }
    
    }
}
