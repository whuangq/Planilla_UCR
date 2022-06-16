using Domain.Agreements.Repositories;
using Domain.Agreements.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Agreements.Implementations
{
    internal class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;

        public AgreementService(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public async Task CreateAgreementAsync(Agreement agreement)

        {
            await _agreementRepository.CreateAgreementAsync(agreement);
        }

        public async Task<Agreement>? GetContractee(Agreement agreement)
        {
            return await _agreementRepository.GetContractee(agreement);
        }

        public Task<IEnumerable<Agreement>> GetEmployeeProjects(string employeeEmail)
        {
            return _agreementRepository.GetEmployeeProjects(employeeEmail);
        }
    }
}
