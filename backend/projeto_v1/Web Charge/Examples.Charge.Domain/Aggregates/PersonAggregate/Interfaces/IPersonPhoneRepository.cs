using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task Add(PersonAggregate.PersonPhone model);
        Task Update(PersonAggregate.PersonPhone model);
        Task<bool> Delete(string phone);
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindByPersonId(int personId);
    }
}
