using System;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.MemberGroups.Queries;
using MasterDance.Application.UseCases.Mobile.Models;
using MasterDance.Application.UseCases.Mobile.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class MobileController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult> GetMemberGroups()
        {
            var result = await Mediator.Send(new GetMemberGroupsQuery.Request());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetMembers(int groupId, DateTime date)
        {
            var result = await Mediator.Send(new GetMembersForEvidenceQuery.Request(){Date = date, GroupId = groupId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveEvidence(MemberModel[] evidence)
        {
            return Ok(evidence);
        }
    }
}