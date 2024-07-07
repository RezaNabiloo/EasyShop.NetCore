using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Features.Product.Requests.Queries;
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
    
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            var data = await _mediator.Send(new GetProductListRequest());
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(long id)
        {
            var data = await _mediator.Send(new GetProductRequest { Id = id });
            return Ok(data);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductCreateDTO dto)
        {
            var data = await _mediator.Send(new CreateProductCommand { ProductCreateDTO = dto });
            return Ok(data);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProductUpdateDTO dto)
        {
            await _mediator.Send(new UpdateProductCommand { Id = id, ProductUpdateDTO = dto });
            return NoContent();

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductCommand{ Id=id});
            return NoContent();
        }
    }
}
