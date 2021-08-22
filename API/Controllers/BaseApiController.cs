using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // controller is a placeholder that gets replaced with the name of the controller class name, minus the word controller
    public class BaseApiController : ControllerBase
    {
        
    }
}