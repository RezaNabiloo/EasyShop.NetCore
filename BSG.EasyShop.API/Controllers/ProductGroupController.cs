using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
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
    
    public class ProductGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductGroupController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductGroupDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetProductGroupListRequest());
            return Ok(countryList);
        }

        // GET api/<ProductGroupController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetProductGroupRequest { Id = id });
            return Ok(country);
        }

        // POST api/<ProductGroupController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductGroupCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProductGroupCommand { ProductGroupCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProductGroupController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProductGroupUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProductGroupCommand { Id = id, ProductGroupUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProductGroupController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductGroupCommand{ Id=id});
            return NoContent();
        }
    }
}
