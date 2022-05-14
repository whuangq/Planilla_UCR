using Domain.Core.Repositories;
using Domain.Persons.DTOs;
using Domain.Persons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persons.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task CreatePersonAsync(String email, int id, String name, String bankAccount);
    }
}
