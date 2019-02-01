using System.Threading.Tasks;
using MasterDance.Application.UseCases.Documents.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MasterDance.WebUI.Controllers
{
    public class DocumentTypesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetDocumentTypes()
        {
            var result = await Mediator.Send(new GetDocumentTypesQuery.Request());
            return Ok(result);
        }
    }
}