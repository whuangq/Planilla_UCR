using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;
using Application.Subscriptions.Implementations;
using Domain.Subscriptions.Repositories;
using Domain.Subscriptions.Entities;
using LanguageExt;

namespace Tests.Application
{
    public class GetBenefitsByProjectTest
    {
        List<Subscription> benefitsList = new List<Subscription>
        {
            new Subscription("leonel@ucr.ac.cr", "Proyecto 1", "Wonder Gym", "Ministerio de salud", "Mensualidad del gimnasio", 12000.0, 1, 1),
            new Subscription("leonel@ucr.ac.cr", "Proyecto 2", "Cine", "Cinepolis", "Entrada y palomitas para 2", 15000.0, 1, 1),
            new Subscription("leonel@ucr.ac.cr", "Proyecto 3", "Tarjeta de regalo", "BAC", "Tarjeta de regalo por 10.000", 10000.0, 1, 1),
        };
        private string _employerEmail = "mau@ucr.ac.cr";
        private string _projectName = "Projecto 1";

        [Fact]
        public async Task GetBenefitsByProject()
        {
            //arrange
            var mockSubscriptionRepository = new Mock<ISubscriptionRepository>();
            var subscriptionService = new SubscriptionService(mockSubscriptionRepository.Object);
            mockSubscriptionRepository.Setup(repo => repo.GetBenefitsByProject(_employerEmail, _projectName)).ReturnsAsync(benefitsList.Where(
                e => e.EmployerEmail == _employerEmail));

            //act
            var benefitsByEmployee = subscriptionService.GetBenefitsByProject(_employerEmail, _projectName);

            //assert
            mockSubscriptionRepository.Verify(repo => repo.GetBenefitsByProject(_employerEmail, _projectName));
            benefitsByEmployee.Count().Should().Equals(3);
        }
    }
}
