using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.Brand.Request.Commands;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<BrandController>
        [HttpGet]        
        public async Task<ActionResult<List<BrandListDTO>>> Get()
        {
            var brandList = await _mediator.Send(new GetBrandListRequest());
            return Ok(brandList);
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> Get(long id)
        {
            var brand = await _mediator.Send(new GetBrandRequest { Id = id });
            return Ok(brand);
        }

        // POST api/<BrandController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] BrandCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateBrandCommand { BrandCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] BrandUpdateDTO dto)
        {
            await _mediator.Send(new UpdateBrandCommand { Id = id, BrandUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteBrandCommand{ Id=id});
            return NoContent();
        }
    }
}
