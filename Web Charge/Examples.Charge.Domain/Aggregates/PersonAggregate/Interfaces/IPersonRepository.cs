using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllAsync();
        Task<Person> FindAsync(int id);
        Task<bool> UpdateAsync(Person person);
        Task<bool> InsertAsync(Person person);
        Task<bool> DeleteAsync(int id);
    }
}
