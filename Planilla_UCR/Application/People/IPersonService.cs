using Domain.People.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.People
{
    public interface IPersonService
    {
        Task CreatePersonAsync(Person personInfo);

        Task<IEnumerable<Person>> GetAllEmployees();
        Task<IEnumerable<Person>> GetProjectEmployees(string projectName);
        Task<IEnumerable<Person>> GetPersonByEmail(string email);
    }
}
