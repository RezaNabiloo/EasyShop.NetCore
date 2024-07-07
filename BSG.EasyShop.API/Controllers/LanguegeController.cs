using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Features.Languege.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class LanguegeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguegeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LanguegeController>
        [HttpGet]        
        public async Task<ActionResult<List<LanguegeDTO>>> Get()
        {
            var languegeList = await _mediator.Send(new GetLanguegeListRequest());
            return Ok(languegeList);
        }

        // GET api/<LanguegeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguegeDTO>> Get(long id)
        {
            var languege = await _mediator.Send(new GetLanguegeRequest { Id = id });
            return Ok(languege);
        }

        // POST api/<LanguegeController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] LanguegeCreateDTO dto)
        {
            var command = await _mediator.Send(new CreateLanguegeCommand { LanguegeCreateDTO = dto });
            return Ok(command);
        }

        // PUT api/<LanguegeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] LanguegeUpdateDTO dto)
        {
            var command = await _mediator.Send(new UpdateLanguegeCommand { Id = id, LanguegeUpdateDTO = dto });
            return Ok(command);

        }

        // DELETE api/<LanguegeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var command = await _mediator.Send(new DeleteLanguegeCommand{ Id=id});
            return Ok(command);
        }
    }
}
