using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.AutoMapper
{
    class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>()
               .ReverseMap();

            CreateMap<PersonPhone, PersonPhoneRequest>()
                .ReverseMap();
        }
    }
}
