using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Products.Commands.CreateProductCommand;
using POS.Application.Features.Products.Commands.DeleteProductCommand;
using POS.Application.Features.Products.Commands.UpdateProductCommand;
using POS.Application.Features.Products.Queries.GetProductById;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //DELETE api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand { ProductId = id }));
        }

        //PUT api/<controller>
        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateProductCommand command)
        {
            if (id != command.ProductId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //GET: api/<controller>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await Mediator.Send(new GetProductByIdQuery { ProductId = id }));
    }
}
