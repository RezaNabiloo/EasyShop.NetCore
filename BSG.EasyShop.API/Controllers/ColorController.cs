using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Features.Color.Requests.Queries;
using BSG.EasyShop.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<ColorController>
        [HttpGet]
        public async Task<ActionResult<List<ColorDTO>>> Get()
        {
            var query = await _mediator.Send(new GetColorListRequest());
            return Ok(query);
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ColorDTO>>> Get(int id)
        {
            var query = await _mediator.Send(new GetColorRequest { Id = id });
            return Ok(query);
        }

        // POST api/<ColorController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] ColorCreateDTO color)
        {
            var command = await _mediator.Send(new CreateColorCommand { ColorCreateDTO = color });
            return Ok(command);
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] ColorUpdateDTO color)
        {
            var command = await _mediator.Send(new UpdateColorCommand { ColorUpdateDTO = color });
            return Ok(command);
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = await _mediator.Send(new DeleteColorCommand { Id = id});
            return Ok(command);
        }
    }
}
