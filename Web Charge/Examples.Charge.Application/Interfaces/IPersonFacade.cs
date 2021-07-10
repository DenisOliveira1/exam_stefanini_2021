using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> FindAsync(int id);
        Task<bool> UpdateAsync(PersonRequest personRequest);
        Task<bool> InsertAsync(PersonRequest personRequest);
        Task<bool> DeleteAsync(int id);
    }
}