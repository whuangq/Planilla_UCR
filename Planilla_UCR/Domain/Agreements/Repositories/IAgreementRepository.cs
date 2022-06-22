using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement?> GetContractee(Agreement agreement);
        Task<IEnumerable<Agreement>> GetEmployeeProjects(string employeeEmail);
        Task<Agreement?> GetFirstProjectAgreement(Agreement searchAgreement);
        Task<IList<Agreement>> GetProjectAgreements(string projectName, string employerEmail);
    }
}
