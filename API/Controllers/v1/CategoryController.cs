using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;
using POS.Application.Features.Categories.Commands.DeleteCategoryCommand;
using POS.Application.Features.Categories.Commands.UpdateCategoryCommand;

namespace POS.WebApi.Controllers.v1
{    
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        //PUT api/<controller>
        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
        {
            if(id != command.CategoryId)            
                return BadRequest();
            
            return Ok(await Mediator.Send(command));
        }
        //DELETE api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            return Ok(await Mediator.Send(new DeleteCategoryCommand {CategoryId = id}));
        }
    }
}
