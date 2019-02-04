using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator)));
    }
}