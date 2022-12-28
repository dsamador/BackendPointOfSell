using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Cutomers.Commands;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
