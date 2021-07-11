using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }
        public async Task<bool> InsertAsync(PersonPhoneRequest phoneRequest)
        {
            var phone = _mapper.Map<PersonPhone>(phoneRequest);
            return await _personPhoneService.InsertAsync(phone);
        }

        public async Task<bool> UpdateAsync(PersonPhoneRequest phoneRequest)
        {
            var phoneRemoving = _mapper.Map<PersonPhone>(phoneRequest);
            var phoneAdding= _mapper.Map<PersonPhone>(phoneRequest.updatedPhone);
            return await _personPhoneService.UpdateAsync(phoneRemoving, phoneAdding);
        }

        public async Task<bool> DeleteAsync(PersonPhoneRequest phoneRequest)
        {
            var phone = _mapper.Map<PersonPhone>(phoneRequest);
            return await _personPhoneService.DeleteAsync(phone);
        }
    }
}
