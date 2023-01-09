using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Products.Commands.CreateProductCommand;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
