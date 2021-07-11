using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonListResponse();
            response.Objects = new List<PersonDto>();
            response.Objects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }
        public async Task<PersonResponse> FindAsync(int id)
        {
            var result = await _personService.FindAsync(id);
            var response = new PersonResponse();
            response.Object = new PersonDto();
            response.Object = _mapper.Map<PersonDto>(result);
            return response;
        }

        public async Task<bool> InsertAsync(PersonRequest personRequest)
        {
            var person = _mapper.Map<Person>(personRequest);
            return await _personService.InsertAsync(person);
        }

        public async Task<bool> UpdateAsync(PersonRequest personRequest)
        {
            var person = _mapper.Map<Person>(personRequest);
            return await _personService.UpdateAsync(person);
        }
        public Task<bool> DeleteAsync(int id) => (_personService.DeleteAsync(id));
    }
}
