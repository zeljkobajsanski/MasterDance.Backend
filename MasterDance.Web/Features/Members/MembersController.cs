using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<GetMemberById.Model>> GetMember([FromRoute]GetMemberById.Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Save([FromBody] SaveMember.Command command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(command));
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
    }
}