using Domain.AgreementTypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.AgreementTypes.Repositories
{
    public interface IAgreementTypeRepository
    {
        Task CreateAgreementTypeAsync(AgreementType agreement);

        Task<IEnumerable<AgreementType>>? GetTypesOfAgreement();

        Task<IEnumerable<AgreementType>>? GetSalaryPerAgreement(int mountPerHour);
        Task<IEnumerable<AgreementType>>? GetAllAgreementTypes();
    }
}
