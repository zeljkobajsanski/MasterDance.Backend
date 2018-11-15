using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
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
    }
}