using Domain.Persons.DTOs;
using Domain.Persons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persons
{
    public interface IPersonService
    {
        Task CreatePersonAsync(String email,int id, String name, String bankAccount);
    }
}
