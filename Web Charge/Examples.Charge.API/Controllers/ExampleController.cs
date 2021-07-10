﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : BaseController
    {
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

        [HttpPost]
        public IActionResult Post([FromBody] ExampleRequest request)
        {
            return Response(0, null);
        }
    }
}
