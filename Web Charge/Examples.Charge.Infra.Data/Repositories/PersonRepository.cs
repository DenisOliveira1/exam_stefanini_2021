using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await _context.Person.Include(x => x.Phones).ToListAsync();
        public async Task<Person> FindAsync(int id)
        {
            var person = await _context.Person.Include(x => x.Phones)
                                .FirstOrDefaultAsync(x => x.BusinessEntityID == id);
            return person;
        }

        public async Task<bool> InsertAsync(Person example)
        {
            _context.Add(example);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            var personUpdating = await _context.Person.FindAsync(person.BusinessEntityID);
            personUpdating.Name = person.Name;
            _context.Entry(personUpdating).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var personDeleting = await _context.Person.FindAsync(id);
            _context.Remove(personDeleting);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
