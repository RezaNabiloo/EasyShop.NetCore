using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.DTOs.ProductTechSpec;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class ProductTechSpecController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTechSpecController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductTechSpecController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductTechSpecDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetProductTechSpecListRequest());
            return Ok(countryList);
        }

        // GET api/<ProductTechSpecController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTechSpecDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetProductTechSpecRequest { Id = id });
            return Ok(country);
        }

        // POST api/<ProductTechSpecController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductTechSpecCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProductTechSpecCommand { ProductTechSpecCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProductTechSpecController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProductTechSpecUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProductTechSpecCommand { Id = id, ProductTechSpecUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProductTechSpecController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductTechSpecCommand{ Id=id});
            return NoContent();
        }
    }
}
