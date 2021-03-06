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

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();
        public async Task<Person> FindAsync(int id) => (await _personRepository.FindAsync(id));
        public async Task<bool> InsertAsync(Person person) => (await _personRepository.InsertAsync(person));
        public async Task<bool> UpdateAsync(Person person) => (await _personRepository.UpdateAsync(person));
        public async Task<bool> DeleteAsync(int id) => (await _personRepository.DeleteAsync(id));

    }
}
