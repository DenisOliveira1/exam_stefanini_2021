using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate
{
    public class ExampleService : IExampleService
    {
        private IExampleRepository _exampleRepository;
        public ExampleService(IExampleRepository exampleService)
        {
            _exampleRepository = exampleService;
        }

        public async Task<List<Example>> FindAllAsync() => (await _exampleRepository.FindAllAsync()).ToList();
        public async Task<Example> FindAsync(int id) => (await _exampleRepository.FindAsync(id));
        public async Task<bool> InsertAsync(Example example) => (await _exampleRepository.InsertAsync(example));
        public async Task<bool> UpdateAsync(Example example) => (await _exampleRepository.UpdateAsync(example));
    }
}
