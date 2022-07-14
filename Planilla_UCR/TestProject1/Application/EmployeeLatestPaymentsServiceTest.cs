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
    public class EmployeeLatestPaymentsServiceTest
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
        private string _employeeEmail = "mau@ucr.ac.cr";

        [Fact]
        public async Task GetEmployeeLatestPayment()
        {

            //arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);
            mockPaymentRepository.Setup(repo => repo.GetEmployeeLatestPayments("mau@ucr.ac.cr")).ReturnsAsync(paymentsList.Where(
                e => e.EmployerEmail == _employeeEmail));

            //act
            var lastestPaymentTest = paymentService.GetEmployeeLatestPayments(_employeeEmail);

            //assert
            mockPaymentRepository.Verify(repo => repo.GetEmployeeLatestPayments(_employeeEmail), Times.Once);
            lastestPaymentTest.Count().Should().Equals(5);
        }
    }
}
