using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MasterDance.Application.Exceptions;
using MasterDance.Application.UseCases.Members.Commands;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.Application.UseCases.Prizes.Commands;
using MasterDance.Application.UseCases.Prizes.Models;
using MasterDance.Application.UseCases.Prizes.Queries;
using MasterDance.WebUI.Extensions;
using MasterDance.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace MasterDance.WebUI.Controllers
{
    public class MembersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MemberModel[]>> GetMembers()
        {
            var members = await Mediator.Send(new GetMembersQuery.Request());
            return Ok(members);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MemberDetailsModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetMember(int id)
        {
            try
            {
                var result = await Mediator.Send(new GetMemberQuery.Request(id));
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MemberDetailsModel>> SaveMember([FromBody] MemberDetailsModel member)
        {
            var result = await Mediator.Send(new SaveMemberCommand.Request(member));
            return Ok(result);
        }

        [HttpGet("{memberId}/documents")]
        [ProducesResponseType(typeof(ICollection<DocumentModel>), 200)]
        public async Task<ActionResult> GetDocuments(int memberId)
        {
            var results = await Mediator.Send(new GetDocumentsForMemberQuery.Request(memberId));
            return Ok(results);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UploadDocument([FromForm][SwaggerFile] DocumentForUpload document)
        {
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

        [HttpGet("{memberId}/memberships")]
        [ProducesResponseType(typeof(ICollection<MembershipModel>), 200)]
        public async Task<ActionResult> GetMemberships(int memberId)
        {
            var results = await Mediator.Send(new GetMembershipsQuery.Request(memberId));
            return Ok(results);
        }

        [HttpGet("{memberId}/prizes")]
        [ProducesResponseType(typeof(ICollection<PrizeModel>), 200)]
        public async Task<ActionResult> GetPrizes(int memberId)
        {
            var result = await Mediator.Send(new GetPrizesQuery.Request(memberId));
            return Ok(result);
        }

        [HttpPost("{memberId}/prizes")]
        [ProducesResponseType(typeof(ICollection<PrizeModel>), 200)]
        public async Task<ActionResult> SavePrize(int memberId, [FromBody] PrizeModel prize)
        {
            var result = await Mediator.Send(new SavePrizeCommand.Request(prize));
            return Ok(result);
        }
        
        [HttpDelete("{memberId}/prizes/{id}")]
        [ProducesResponseType(typeof(ICollection<PrizeModel>), 200)]
        public async Task<ActionResult> DeletePrize(int memberId, int id)
        {
            var result = await Mediator.Send(new DeletePrizeCommand.Request(id, memberId));
            return Ok(result);
        }
    }
}