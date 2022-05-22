using System;
using System.Threading.Tasks;

namespace Domain.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(String email);
    }
}
