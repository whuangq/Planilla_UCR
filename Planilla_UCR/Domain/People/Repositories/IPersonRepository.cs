using System.Threading.Tasks;
using Domain.People.Entities;
using Domain.People.DTOs;
using System.Collections.Generic;

namespace Domain.People.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);
        Task<IEnumerable<Person>> GetAllEmployees();
    }
}
