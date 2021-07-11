using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await _context.PersonPhone
                                                                                    .Include(x => x.Person)
                                                                                    .Include(x => x.PhoneNumberType)
                                                                                    .ToListAsync();

        public async Task<bool> InsertAsync(PersonPhone personPhone)
        {
            _context.Add(personPhone);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(PersonPhone phoneRemoving, PersonPhone phoneAdding)
        {
            _context.Remove(phoneRemoving);
            _context.Add(phoneAdding);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(PersonPhone personPhone)
        {
            _context.Remove(personPhone);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
