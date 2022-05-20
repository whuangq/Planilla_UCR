using Domain.Persons.Entities;
using Domain.Persons.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Persons
{
    public interface IPersonService
    {
        Task CreatePersonAsync(Person personInfo);

        Task<IEnumerable<Person>> GetAllEmployees();
    }
}
