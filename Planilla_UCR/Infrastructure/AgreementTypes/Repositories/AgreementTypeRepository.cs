using Domain.Core.Repositories;
using Domain.AgreementTypes.Entities;
using Domain.AgreementTypes.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.AgreementTypes.Repositories
{
    internal class AgreementTypeRepository : IAgreementTypeRepository
    {
        private readonly AgreementTypeDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementTypeRepository(AgreementTypeDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementTypeAsync(AgreementType agreement)

        {
            _dbContext.AgreementTypes.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }
  
        public async Task<IEnumerable<AgreementType>>? GetTypesOfAgreement() 
        {
            var agreementTypeList = await _dbContext.AgreementTypes.FromSqlRaw("EXEC GetTypesOfAgreement").ToListAsync();
            return agreementTypeList;
        }


        public async Task<IEnumerable<AgreementType?>> GetSalaryPerAgreement(int Agreement)
        {
            var agreementsSalary = await _dbContext.AgreementTypes.FromSqlRaw("EXEC GetSalaryPerAgreement @Agreement",
                new SqlParameter("@Agreement", Agreement)).ToListAsync();
            return agreementsSalary;

        }
    }
}
