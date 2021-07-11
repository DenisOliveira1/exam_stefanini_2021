using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<bool> InsertAsync(PersonPhone personPhone);
        Task<bool> UpdateAsync(PersonPhone phoneRemoving, PersonPhone phoneAdding);
        Task<bool> DeleteAsync(PersonPhone personPhone);
    }
}
