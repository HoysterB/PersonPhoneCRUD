using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task Add(PersonPhone model) => await _personPhoneRepository.Add(model);

        public async Task<bool> Delete(string phone) => await _personPhoneRepository.Delete(phone);

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<List<PersonPhone>> FindByPersonId(int personId) => (await _personPhoneRepository.FindByPersonId(personId)).ToList();

        public Task Update(PersonPhone model)
        {
            throw new System.NotImplementedException();
        }
    }
}
