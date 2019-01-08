using System.Threading.Tasks;
using MasterDance.Web.Data.Dto;
using MasterDance.Web.Features.Competitions.Commands;
using MasterDance.Web.Features.Competitions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.Web.Features.Competitions
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompetitionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCompetition([FromBody] CompetitionDto competition)
        {
            var id = await _mediator.Send(new SaveCompetition.Input() {CompetitionDto = competition});
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetitions()
        {
            var result = await _mediator.Send(new GetCompetitions.Input());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCompetition([FromRoute] int id)
        {
            var competitions = await _mediator.Send(new DeleteCompetition.Input() {Id = id});
            return Ok(competitions);
        }
    }
}