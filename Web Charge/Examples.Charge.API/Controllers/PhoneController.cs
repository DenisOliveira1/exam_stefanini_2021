using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : BaseController
    {

        private IPersonPhoneFacade _facade;

        public PhoneController(IPersonPhoneFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonPhoneRequest phoneRequest)
        {
            if (await _facade.InsertAsync(phoneRequest)) return Ok();
            return BadRequest("failed to insert phone");
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(PersonPhoneRequest phoneRequest)
        {
            if (await _facade.UpdateAsync(phoneRequest)) return Ok();
            return BadRequest("failed to update phone");
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PersonPhoneRequest phoneRequest)
        {
            if (await _facade.DeleteAsync(phoneRequest)) return Ok();
            return BadRequest("failed to delete phone");
        }
    }
}
