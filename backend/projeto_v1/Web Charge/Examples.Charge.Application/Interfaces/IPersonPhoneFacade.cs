using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhoneResponse> Add(PersonPhoneDto model);
        Task<PersonPhoneResponse> Update(PersonPhoneDto model);
        Task Delete(string phone);
        Task<List<PersonPhone>> GetByPesonId(int personId);
    }
}
