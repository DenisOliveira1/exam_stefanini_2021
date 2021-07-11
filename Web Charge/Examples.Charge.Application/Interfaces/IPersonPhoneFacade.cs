using Examples.Charge.Application.Messages.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<bool> InsertAsync(PersonPhoneRequest phoneRequest);
        Task<bool> UpdateAsync(PersonPhoneRequest phoneRequest);
        Task<bool> DeleteAsync(PersonPhoneRequest phoneRequest);
    }
}
