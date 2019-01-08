using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Features.Members.Commands;
using MasterDance.Web.Features.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.Web.Features.Members
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetMembers.Model>>> GetMembers()
        {
            return Ok(await _mediator.Send<List<GetMembers.Model>>(new GetMembers.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMemberById.Dto>> GetMember([FromRoute]GetMemberById.Request request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Save([FromBody] SaveMember.Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(dto));
        }

        [HttpGet("{memberId}/documents")]
        public async Task<ActionResult<IList<GetDocumentsForMember.Model>>> GetDocumentsForMember([FromRoute] GetDocumentsForMember.Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("{memberId}/documents")]
        public async Task<ActionResult<int>> AddDocument([FromForm] AddDocument.Command command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpDelete("{memberId}/documents/{documentId}")]
        public async Task<ActionResult<int>> DeleteDocument([FromRoute] int memberId, int documentId)
        {
            var result = await _mediator.Send(new DeleteDocument.Input{DocumentId = documentId});
            return Ok(result);
        }

        [HttpPost("{memberId}/prizes")]
        public async Task<IActionResult> SavePrize([FromBody] PrizeDto prizeDto)
        {
            var data = await _mediator.Send(new SavePrize.Input() {PrizeDto = prizeDto});
            return Ok(data);
        }

        [HttpGet("{memberId}/prizes")]
        public async Task<IActionResult> GetMemberPrizes([FromRoute] int memberId)
        {
            var result = await _mediator.Send(new GetMemberPrizes.Input() {MemberId = memberId});
            return Ok(result);
        }

        [HttpDelete("{memberId}/prizes/{prizeId}")]
        public async Task<IActionResult> RemoveMemberPrize([FromRoute] int memberId, [FromRoute] int prizeId)
        {
            var result = await _mediator.Send(new DeletePrize.Input() {MemberId = memberId, PrizeId = prizeId});
            return Ok(result);
        }

        [HttpGet("{memberId}/membership")]
        public async Task<IActionResult> GetMemberships([FromRoute] int memberId)
        {
            var results = await _mediator.Send(new GetMemberships.Input() {MemberId = memberId});
            return Ok(results);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetExpiringDocuments()
        {
            var result = await _mediator.Send(new GetNotifications.Input());
            return Ok(result);
        }
    }
}