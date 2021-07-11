using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.AutoMapper
{
    class PersonProfile : Profile
    {
        public PersonProfile()
        {

            CreateMap<Person, PersonDto>()
                .ReverseMap();

            CreateMap<Person, PersonRequest>()
                .ReverseMap();
        }
    }
}
