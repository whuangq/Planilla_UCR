using System.Threading.Tasks;
using Domain.Persons.Entities;

namespace Domain.Persons.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);
    }
}
