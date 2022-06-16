using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Agreements.Entities;

namespace Application.Agreements
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement>? GetContractee(Agreement agreement);
        Task<IEnumerable<Agreement>> GetEmployeeProjects(string employeeEmail);

    }
}
