using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Dashboard.Models;
using MasterDance.Application.UseCases.Dashboard.Queries;
using MasterDance.Application.UseCases.Memberships.Commands;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class MembershipsController : BaseController
    {
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult> CalculateMemberships(CalculateMembershipCommand.Request request)
        {
            await Mediator.Send(request);
            return Ok(true);
        }

        [HttpGet("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ICollection<DebtModel>))]
        public async Task<ActionResult> GetDebtList()
        {
            var result = await Mediator.Send(new GetDebtList.Request());
            return Ok(result);
        }
    }
}