using Domain.Persons.Entities;
using System.Threading.Tasks;

namespace Application.Persons
{
    public interface IPersonService
    {
        Task CreatePersonAsync(Person personInfo);
    }
}
