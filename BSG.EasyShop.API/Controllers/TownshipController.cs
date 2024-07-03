using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Features.Township.Requests.Queries;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class TownshipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TownshipController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<TownshipController>
        [HttpGet]        
        public async Task<ActionResult<List<TownshipDTO>>> Get()
        {
            var brandList = await _mediator.Send(new GetTownshipListRequest());
            return Ok(brandList);
        }

        // GET api/<TownshipController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TownshipDTO>> Get(long id)
        {
            var brand = await _mediator.Send(new GetTownshipRequest { Id = id });
            return Ok(brand);
        }

        // POST api/<TownshipController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] TownshipCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateTownshipCommand { TownshipCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<TownshipController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] TownshipUpdateDTO dto)
        {
            await _mediator.Send(new UpdateTownshipCommand { Id = id, TownshipUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<TownshipController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteTownshipCommand{ Id=id});
            return NoContent();
        }
    }
}
