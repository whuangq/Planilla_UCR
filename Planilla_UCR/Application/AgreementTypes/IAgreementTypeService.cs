using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AgreementTypes.Entities;

namespace Application.AgreementTypes
{
    public interface IAgreementTypeService
    {
        Task CreateAgreementTypeAsync(AgreementType agreement);

        Task<IEnumerable<AgreementType>>? GetTypesOfAgreement();
        Task<IEnumerable<AgreementType>>? GetSalaryPerAgreement(int mountPerHour);
    }
}
