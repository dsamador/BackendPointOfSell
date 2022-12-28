using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;
using POS.Application.Features.Categories.Commands.DeleteCategoryCommand;
using POS.Application.Features.Categories.Commands.UpdateCategoryCommand;
using POS.Application.Features.Categories.Queries.GetAllCategories;
using POS.Application.Features.Categories.Queries.GetCategoryById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace POS.WebApi.Controllers.v1
{    
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {
        //GET: api/<controller>
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery { 
                PageNumber = filter.PageNumber, 
                PageSize =filter.PageSize,
                Name = filter.Name
            }));
        }

        //GET: api/<controller>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { CategoryId = id }));
        }

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
