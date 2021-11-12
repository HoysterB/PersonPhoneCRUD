using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<List<Person>> FindAllAsync();
        Task<PersonResponse> FindById(int id);
        Task<PersonResponse> Add(PersonDto model);
        Task<PersonResponse> Update(PersonDto model);
        Task<PersonResponse> AddPhoneNumber(PersonDto model);
        Task Delete(int modelId);
    }
}