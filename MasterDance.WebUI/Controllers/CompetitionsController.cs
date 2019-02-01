using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Competitions.Commands;
using MasterDance.Application.UseCases.Competitions.Models;
using MasterDance.Application.UseCases.Competitions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class CompetitionsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<CompetitionModel>), 200)]
        public async Task<ActionResult> GetCompetitions()
        {
            var result = await Mediator.Send(new GetCompetitionsQuery.Request());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<ActionResult> SaveCompetition([FromBody] CompetitionModel competition)
        {
            var result = await Mediator.Send(new SaveCompetitionCommand.Request(competition));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ICollection<CompetitionModel>), 200)]
        public async Task<ActionResult> DeleteCompetition(int id)
        {
            var result = await Mediator.Send(new DeleteCompetitionCommand.Request(id));
            return Ok(result);
        }
    }
}