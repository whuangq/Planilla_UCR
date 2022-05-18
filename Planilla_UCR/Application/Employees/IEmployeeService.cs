using System;
using System.Threading.Tasks;

namespace Application.Employees
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(String email);
    }
}
