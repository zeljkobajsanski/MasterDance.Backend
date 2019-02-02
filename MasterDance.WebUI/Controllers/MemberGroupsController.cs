using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.MemberGroups.Commands;
using MasterDance.Application.UseCases.MemberGroups.Models;
using MasterDance.Application.UseCases.MemberGroups.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class MemberGroupsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<MemberGroupModel>), 200)]
        public async Task<ActionResult> GetMemberGroups()
        {
            var result = await Mediator.Send(new GetMemberGroupsQuery.Request());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<MemberGroupModel>), 200)]
        public async Task<ActionResult> SaveMemberGroup([FromBody] MemberGroupModel model)
        {
            var result = await Mediator.Send(new SaveMemberGroupCommand.Request(model));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ICollection<MemberGroupModel>), 200)]
        public async Task<ActionResult> DeleteMemberGroupById(int id)
        {
            var result = await Mediator.Send(new DeleteMemberGroupCommand.Request(id));
            return Ok(result);
        }
    }
}