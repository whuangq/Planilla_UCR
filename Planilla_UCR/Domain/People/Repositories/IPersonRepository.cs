using System.Threading.Tasks;
using Domain.People.Entities;
using System.Collections.Generic;

namespace Domain.People.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);
        Task<IEnumerable<Person>> GetAllEmployees();
        Task<IEnumerable<Person>> GetProjectEmployees(string projectName);
        Task<IEnumerable<Person>> GetPersonByEmail(string email);
    }
}
