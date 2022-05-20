using System;
using System.Threading.Tasks;

namespace Domain.Employers.Repositories
{
    public interface IEmployerRepository
    {
        Task CreateEmployerAsync(String email);
    }
}
