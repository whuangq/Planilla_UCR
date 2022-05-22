using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.People.Entities;
using System;
using System.Collections.Generic;



namespace Domain.Persons.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInfo);

        //Task<Person?> GetAccountEmail(String email);
    }
}
