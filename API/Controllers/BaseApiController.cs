using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // controller is a placeholder that gets replaced with the name of the controller class name, minus the word controller
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // protected is available to any derived classes + this class
        // ??= null coalescing assignment operator
        // set Mediator to _mediator, but if its null, it'll assign Mediator to whatever is to the right of ??=
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
    }
}