using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Commands;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Queries;
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
    
    public class ProductImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductImageController>
        [HttpGet]        
        public async Task<ActionResult<List<ProductImageDTO>>> Get()
        {
            var countryList = await _mediator.Send(new GetProductImageListRequest());
            return Ok(countryList);
        }

        // GET api/<ProductImageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageDTO>> Get(long id)
        {
            var country = await _mediator.Send(new GetProductImageRequest { Id = id });
            return Ok(country);
        }

        // POST api/<ProductImageController>
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] ProductImageCreateDTO dto)
        {
            var id = await _mediator.Send(new CreateProductImageCommand { ProductImageCreateDTO = dto });
            return Ok(id);
        }

        // PUT api/<ProductImageController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(long id, [FromBody] ProductImageUpdateDTO dto)
        //{
        //    await _mediator.Send(new UpdateProductImageCommand { Id = id, ProductImageUpdateDTO = dto });
        //    return NoContent();

        //}

        // DELETE api/<ProductImageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteProductImageCommand{ Id=id});
            return NoContent();
        }
    }
}
