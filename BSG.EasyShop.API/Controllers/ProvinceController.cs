using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Features.Province.Requests.Queries;
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
    
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProvinceController>
        [HttpGet]        
        public async Task<ActionResult<List<ProvinceDTO>>> Get()
        {
            var brandList = await _mediator.Send(new GetProvinceListRequest());
            return Ok(brandList);
        }

        // GET api/<ProvinceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinceDTO>> Get(long id)
        {
            var brand = await _mediator.Send(new GetProvinceRequest { Id = id });
            return Ok(brand);
        }

        // POST api/<ProvinceController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProvinceCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProvinceCommand { ProvinceCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProvinceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProvinceUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProvinceCommand { Id = id, ProvinceUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProvinceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProvinceCommand{ Id=id});
            return NoContent();
        }
    }
}
