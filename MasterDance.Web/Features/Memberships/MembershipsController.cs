using System.Threading.Tasks;
using MasterDance.Web.Features.Memberships.Commands;
using MasterDance.Web.Features.Memberships.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.Web.Features.Memberships
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateMemberships()
        {
            await _mediator.Send(new GenerateMembership.Input());
            return Ok(1);
        }

        [HttpPost("{membershipId}/payments")]
        public async Task<IActionResult> AddPayment([FromRoute] int membershipId, [FromBody] AddPayment.Input payment)
        {
            var memberships = await _mediator.Send(payment);
            return Ok(memberships);
        }

        [HttpDelete("{membershipId}/payments")]
        public async Task<IActionResult> RemovePayments([FromRoute] int membershipId)
        {
            var memberships = await _mediator.Send(new DeletePayments.Input{MembershipId = membershipId});
            return Ok(memberships);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBalanceSheet()
        {
            var result = await _mediator.Send(new GetBalanceSheet.Input());
            return Ok(result);
        }
    }
}