using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task Add(PersonPhone model);
        Task Update(PersonPhone model);
        Task<bool> Delete(string phone);
        Task<List<PersonPhone>> FindByPersonId(int personId);
    }
}
