using System.Threading.Tasks;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Features.MemberGroups.Commands;
using MasterDance.Web.Features.MemberGroups.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.Web.Features.MemberGroups
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MemberGroupDto memberGroupDto)
        {
            var memberGroups = await _mediator.Send(new SaveMemberGroup.Input() {MemberGroupDto = memberGroupDto});
            return Ok(memberGroups);
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberGroups()
        {
            var memberGroups = await _mediator.Send(new GetMemberGroups.Input());
            return Ok(memberGroups);
        }

        [HttpDelete("{memberGroupId}")]
        public async Task<IActionResult> DeleteMemberGroup([FromRoute] int memberGroupId)
        {
            var memberGroups = await _mediator.Send(new DeleteGroupById.Input() {Id = memberGroupId});
            return Ok(memberGroups);
        }
    }
}