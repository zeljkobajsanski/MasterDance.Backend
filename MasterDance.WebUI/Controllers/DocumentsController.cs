using System.Threading.Tasks;
using MasterDance.Application.UseCases.Documents.Models;
using MasterDance.Application.UseCases.Documents.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class DocumentsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(DocumentModel), 200)]
        public async Task<ActionResult> GetDocument(int id)
        {
            var result = await Mediator.Send(new GetDocumentQuery.Request(id));
            return Ok(result);
        }
    }
}