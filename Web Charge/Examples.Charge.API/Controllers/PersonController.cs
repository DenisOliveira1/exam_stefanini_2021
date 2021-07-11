using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {

        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetById(int id)
        {
            var response = await _facade.FindAsync(id);
            return Response(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] PersonRequest personRequest)
        {
            if (await _facade.UpdateAsync(personRequest)) return NoContent();
            return BadRequest("failed to update example");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonRequest personRequest)
        {
            if (await _facade.InsertAsync(personRequest)) return Ok();
            return BadRequest("failed to insert example");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _facade.DeleteAsync(id)) return Ok();
            return BadRequest("failed to delete example");
        }
    }
}
