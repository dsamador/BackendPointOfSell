using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Cutomers.Commands.CreateCustomerCommand;
using POS.Application.Features.Cutomers.Commands.DeleteCustomerCommand;
using POS.Application.Features.Cutomers.Commands.UpdateCustomerCommand;
using POS.Application.Features.Cutomers.Queries;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        //GET: api/<controller>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)        
            => Ok(await Mediator.Send(new GetCustomerByIdQuery { CustomerId = id }));
        

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)        
            => Ok(await Mediator.Send(command));
        

        //PUT api/<controller>
        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await Mediator.Send(new DeleteCustomerCommand { CustomerId = id }));
    }
}
