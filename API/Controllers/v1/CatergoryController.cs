using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Features.Categories.Commands.CreateCategoryCommand;

namespace POS.WebApi.Controllers.v1
{    
    [ApiVersion("1.0")]
    public class CatergoryController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
