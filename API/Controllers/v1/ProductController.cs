using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Products.Commands.CreateProductCommand;
using POS.Application.Features.Products.Commands.UpdateProductCommand;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {

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
    }
}
