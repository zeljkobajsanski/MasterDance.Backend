using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Dashboard.Models;
using MasterDance.Application.UseCases.Memberships.Commands;
using MasterDance.Application.UseCases.Memberships.Queries;
using MasterDance.Persistence.QueryTypes;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Annotations;
using GetDebtList = MasterDance.Application.UseCases.Dashboard.Queries.GetDebtList;

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

        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<MembershipsAndPayments>))]
        public async Task<ActionResult> GetMembershipsAndPayments()
        {
            var result = await Mediator.Send(new GetMembershipsQuery.Request());
            return Ok(result);
        }
    }
}