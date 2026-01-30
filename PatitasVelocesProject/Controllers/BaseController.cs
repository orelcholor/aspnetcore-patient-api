using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatitasVelocesProject.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult? ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
