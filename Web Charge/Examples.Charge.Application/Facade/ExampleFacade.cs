using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class ExampleFacade : IExampleFacade
    {
        private IExampleService _exampleService;
        private IMapper _mapper;

        public ExampleFacade(IExampleService exampleService, IMapper mapper)
        {
            _exampleService = exampleService;
            _mapper = mapper;
        }

        public async Task<ExampleListResponse> FindAllAsync()
        {
            var result = await _exampleService.FindAllAsync();
            var response = new ExampleListResponse();
            response.Objects = new List<ExampleDto>();
            response.Objects.AddRange(result.Select(x => _mapper.Map<ExampleDto>(x)));
            return response;
        }
        public async Task<ExampleResponse> FindAsync(int id)
        {
            var result = await _exampleService.FindAsync(id);
            var response = new ExampleResponse();
            response.Object = new ExampleDto();
            response.Object = _mapper.Map<ExampleDto>(result);
            return response;
        }

        public async Task<bool> InsertAsync(ExampleRequest exampleRequest)
        {
            var example = _mapper.Map<Example>(exampleRequest);
            return await _exampleService.InsertAsync(example);
        }

        public async Task<bool> UpdateAsync(ExampleRequest exampleRequest)
        {
            var example = _mapper.Map<Example>(exampleRequest);
            return await _exampleService.UpdateAsync(example);
        }
        public Task<bool> DeleteAsync(int id) => (_exampleService.DeleteAsync(id));
    }
}
