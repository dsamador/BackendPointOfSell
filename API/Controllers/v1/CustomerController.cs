using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Cutomers.Commands.CreateCustomerCommand;
using POS.Application.Features.Cutomers.Commands.DeleteCustomerCommand;

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

        //DELETE api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand { CustomerId = id }));
        }
    }
}
