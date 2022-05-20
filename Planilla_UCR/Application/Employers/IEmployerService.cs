using Domain.Persons.DTOs;
using Domain.Persons.Entities;
using System;
using System.Threading.Tasks;


namespace Application.Employers
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(String email);
    }
}
