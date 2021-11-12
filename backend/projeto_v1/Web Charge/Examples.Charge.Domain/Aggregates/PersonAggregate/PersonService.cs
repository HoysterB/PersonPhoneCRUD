using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task Add(Person model) => await _personRepository.Add(model);

        public async Task AddPhoneNumber(Person model) => await _personRepository.AddPhoneNumber(model);
        public async Task<bool> Delete(int id) => await _personRepository.Delete(id);

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> FindByIdAsync(int id) => await _personRepository.FindByIdAsync(id);

        public async Task Update(Person model) => await _personRepository.Update(model);
    }
}
