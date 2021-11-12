using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();
        Task<PersonAggregate.Person> FindByIdAsync(int id);
        Task Add(PersonAggregate.Person model);
        Task Update(PersonAggregate.Person model);
        Task AddPhoneNumber(PersonAggregate.Person model);
        Task<bool> Delete(int id);
    }
}
