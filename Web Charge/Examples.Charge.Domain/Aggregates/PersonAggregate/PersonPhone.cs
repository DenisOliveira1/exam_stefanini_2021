using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone
    {
        //[Key]
        //[Column(Order = 0)]
        //[ForeignKey("Person")]
        public int BusinessEntityID { get; set; }
        //[Key]
        //[Column(Order = 1)]
        public string PhoneNumber { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //[ForeignKey("PhoneNumberType")]
        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();
    }
}
