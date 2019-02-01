using System.Threading.Tasks;
using MasterDance.Application.UseCases.Members.Commands;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class MembersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MemberModel>> GetMembers()
        {
            var members = await Mediator.Send(new GetMembers.Request());
            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDetailsModel>> SaveMember([FromForm] MemberDetailsModel member)
        {
            var result = await Mediator.Send(new SaveMember.Request(member));
            return Ok(result);
        }
    }
}