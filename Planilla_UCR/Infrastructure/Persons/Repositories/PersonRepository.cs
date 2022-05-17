using Domain.Core.Repositories;
using Domain.Persons.Entities;
using Domain.Persons.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Persons.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PersonRepository(PersonDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreatePersonAsync(Person personInfo)
        {
            _dbContext.Persons.Add(personInfo);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
