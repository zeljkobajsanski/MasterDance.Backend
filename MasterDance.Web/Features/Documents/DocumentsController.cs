using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MasterDance.Web.Features.Documents.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace MasterDance.Web.Features.Documents
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetDocumentTypes()
        {
            return Ok(await _mediator.Send(new Queries.GetDocumentTypes.Request()));
        }

        [HttpGet("{documentId}")]
        public async Task<ActionResult<GetDocumentById.Output>> GetDocumentById([FromRoute]GetDocumentById.Input input)
        {
            var output = await _mediator.Send(input);
            return Ok(output);
        }
    }
}