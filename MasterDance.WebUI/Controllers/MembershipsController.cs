using System.Threading.Tasks;
using MasterDance.Application.UseCases.Memberships.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class MembershipsController : BaseController
    {
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult> CalculateMemberships([FromQuery]  int year, int month)
        {
            await Mediator.Send(new CalculateMembershipCommand.Request(year, month));
            return Ok(true);
        }
    }
}