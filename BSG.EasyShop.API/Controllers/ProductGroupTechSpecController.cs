using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Queries;
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
    
    public class ProductGroupTechSpecController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductGroupTechSpecController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductGroupTechSpecController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductGroupTechSpecDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetProductGroupTechSpecListRequest());
            return Ok(countryList);
        }

        // GET api/<ProductGroupTechSpecController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupTechSpecDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetProductGroupTechSpecRequest { Id = id });
            return Ok(country);
        }

        // POST api/<ProductGroupTechSpecController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductGroupTechSpecCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProductGroupTechSpecCommand { ProductGroupTechSpecCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProductGroupTechSpecController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProductGroupTechSpecUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProductGroupTechSpecCommand { Id = id, ProductGroupTechSpecUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProductGroupTechSpecController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductGroupTechSpecCommand{ Id=id});
            return NoContent();
        }
    }
}
