using System.Threading.Tasks;
using MasterDance.Web.Features.Dashboard.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.Web.Features.Dashboard
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOverallStatistics()
        {
            var result = await _mediator.Send(new GetOverallStatistics.Input());
            return Ok(result);
        }
    }
}