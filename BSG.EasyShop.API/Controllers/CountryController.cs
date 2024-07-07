using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Features.Country.Requests.Queries;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CountryController>
        [HttpGet]        
        public async Task<ActionResult<List<CountryDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetCountryListRequest());
            return Ok(countryList);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetCountryRequest { Id = id });
            return Ok(country);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] CountryCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateCountryCommand { CountryCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] CountryUpdateDTO dto)
        {
            await _mediator.Send(new UpdateCountryCommand { Id = id, CountryUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteCountryCommand{ Id=id});
            return NoContent();
        }
    }
}
