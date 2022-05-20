using System.Threading.Tasks;
using Domain.Persons.Entities;
using Domain.Persons.DTOs;
using System.Collections.Generic;

namespace Domain.Persons.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);
        Task<IEnumerable<Person>> GetAllEmployees();
    }
}
