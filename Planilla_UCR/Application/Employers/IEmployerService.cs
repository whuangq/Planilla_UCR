using System;
using System.Threading.Tasks;


namespace Application.Employers
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(String email);
    }
}
