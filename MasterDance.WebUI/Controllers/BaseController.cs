using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using IdentityModel;
using IdentityServer4.Extensions;
using MasterDance.Common;
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

        protected int GetUserId()
        {
            return int.Parse(((ClaimsIdentity) User.Identity).Claims.First(x => x.Type == Constants.CustomClaims.PersonId).Value);
        }
    }
}