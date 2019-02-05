using System;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.MemberGroups.Queries;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.Application.UseCases.Mobile.Commands;
using MasterDance.Application.UseCases.Mobile.Models;
using MasterDance.Application.UseCases.Mobile.Queries;
using MasterDance.Application.UseCases.Payments.Commands;
using MasterDance.Application.UseCases.Payments.Models;
using MasterDance.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class MobileController : BaseController
    {
        private readonly IDateTime _dateTime;

        public MobileController(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        [HttpGet]
        public async Task<ActionResult> GetMemberGroups()
        {
            var result = await Mediator.Send(new GetMemberGroupsQuery.Request());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetEvidence(int groupId)
        {
            var result = await Mediator.Send(new GetMembersForEvidenceQuery.Request(){Date = _dateTime.Now, CoachId = 1, GroupId = groupId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveEvidence(SaveEvidenceModel model)
        {
            model.CoachId = 1;
            await Mediator.Send(new SaveEvidenceCommand.Request(model));
            return Ok(true);
        }

        [HttpGet]
        public async Task<ActionResult> GetMembers()
        {
            var results = await Mediator.Send(new GetMembersQuery.Request());
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult> MakePayment([FromBody] PaymentModel payment)
        {
            var result = await Mediator.Send(new AddPaymentCommand.Request() { Payment = payment, Creator = GetUserId() });
            return Ok(result);
        }
    }
}