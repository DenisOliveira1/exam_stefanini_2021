
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IExampleFacade
    {
        Task<ExampleListResponse> FindAllAsync();
        Task<ExampleResponse> FindAsync(int id);
        Task<bool> UpdateAsync(ExampleRequest exampleRequest);
        Task<bool> InsertAsync(ExampleRequest exampleRequest);
    }
}
