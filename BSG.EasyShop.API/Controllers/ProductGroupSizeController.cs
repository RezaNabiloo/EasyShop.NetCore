using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Queries;
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
    
    public class ProductGroupSizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductGroupSizeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductGroupSizeController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductGroupSizeDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetProductGroupSizeListRequest());
            return Ok(countryList);
        }

        // GET api/<ProductGroupSizeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupSizeDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetProductGroupSizeRequest { Id = id });
            return Ok(country);
        }

        // POST api/<ProductGroupSizeController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductGroupSizeCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProductGroupSizeCommand { ProductGroupSizeCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProductGroupSizeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProductGroupSizeUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProductGroupSizeCommand { Id = id, ProductGroupSizeUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProductGroupSizeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductGroupSizeCommand{ Id=id});
            return NoContent();
        }
    }
}
