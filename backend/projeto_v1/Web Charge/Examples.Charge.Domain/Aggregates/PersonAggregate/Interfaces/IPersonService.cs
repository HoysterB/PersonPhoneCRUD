using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<Person> FindByIdAsync(int id);
        Task Add(Person model);
        Task Update(Person model);
        Task AddPhoneNumber(Person model);
        Task<bool> Delete(int id);

    }
}
