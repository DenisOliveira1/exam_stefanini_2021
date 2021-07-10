using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {

        //Controller        >       Facade      >       Service         >       Repository
        //                          _Mapper

        private IExampleFacade _facade;

        public ExampleController(IExampleFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<ExampleListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleResponse>> GetById(int id)
        {
            var response = await _facade.FindAsync(id);
            return Response(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ExampleRequest exampleRequest)
        {
            if (await _facade.UpdateAsync(exampleRequest)) return NoContent();
            return BadRequest("Failed to update example");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExampleRequest exampleRequest)
        {
            if (await _facade.InsertAsync(exampleRequest)) return Ok();
            return BadRequest("Failed to insert example");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _facade.DeleteAsync(id)) return Ok();
            return BadRequest("Failed to delete example");
        }
    }
}
