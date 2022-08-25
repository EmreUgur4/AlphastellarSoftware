using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmreUgur.BackedProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return Problem(detail: "There was an error in the api, it will be fixed as soon as possible");
        }
    }
}
