using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDance.Application.UseCases.Members.Commands;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.WebUI.Extensions;
using MasterDance.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class MembersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MemberModel>> GetMembers()
        {
            var members = await Mediator.Send(new GetMembersQuery.Request());
            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDetailsModel>> SaveMember([FromForm] MemberDetailsModel member)
        {
            var result = await Mediator.Send(new SaveMemberCommand.Request(member));
            return Ok(result);
        }

        [HttpPost("{memberId}/documents")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UploadDocument(int memberId, [FromForm][SwaggerFile] DocumentForUpload document)
        {
            document.File.ToBase64();
            var result = await Mediator.Send(new UploadDocumentCommand.Request(new DocumentModel()
            {
                MemberId = document.MemberId,
                DocumentType = document.DocumentTypeId,
                FileName = document.File.FileName,
                Content = document.File.ToBase64(),
                ContentType = document.File.ContentType,
                ExpirationDate = document.Date
            }));
            return Ok(await Task.FromResult(result));
        }

        [HttpDelete("{memberId}/documents/{documentId}")]
        [ProducesResponseType(typeof(ICollection<DocumentModel>), 200)]
        public async Task<ActionResult> DeleteDocument(int memberId, int documentId)
        {
            var result = await Mediator.Send(new DeleteDocumentCommand.Request(documentId, memberId));
            return Ok(result);
        }
    }
}