using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly ExampleContext _context;

        public ExampleRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Example>> FindAllAsync() => await Task.Run(() => _context.Example);
        public async Task<Example> FindAsync(int id)
        {
            var example = await _context.Example.FindAsync(id);
            return example;
        }

        public async Task<bool> InsertAsync(Example example)
        {
            _context.Add(example);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Example example)
        {
            var exampleUpdating = await _context.Example.FindAsync(example.Id);
            exampleUpdating.Nome = example.Nome;
            _context.Entry(exampleUpdating).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exampleDeleting = await _context.Example.FindAsync(id);
            _context.Remove(exampleDeleting);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
