using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces
{
    public interface IExampleRepository
    {
        Task<IEnumerable<Example>> FindAllAsync();
        Task<Example> FindAsync(int id);
        Task<bool> UpdateAsync(Example example);
        Task<bool> InsertAsync(Example example);
        Task<bool> DeleteAsync(int id);
    }
}
