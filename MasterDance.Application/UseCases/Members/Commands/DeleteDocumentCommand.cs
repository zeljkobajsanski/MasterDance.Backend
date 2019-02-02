using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Exceptions;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
using MasterDance.Application.UseCases.Members.Queries;
using MasterDance.Domain.Entities;
using MasterDance.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.Application.UseCases.Members.Commands
{
    public class DeleteDocumentCommand
    {
        public class Request : IRequest<ICollection<DocumentModel>>
        {
            public int Id { get; }
            public int MemberId { get; }

            public Request(int id, int memberId)
            {
                Id = id;
                MemberId = memberId;
            }
        }

        public class Handler : RequestHandlerBase<Request, ICollection<DocumentModel>>
        {
            private readonly IMediator _mediator;
            public Handler(MasterDanceDbContext dbContext, IMediator mediator) : base(dbContext)
            {
                _mediator = mediator;
            }

            public override async Task<ICollection<DocumentModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                await DbContext.Database.ExecuteSqlCommandAsync($"DELETE FROM Documents WHERE Id={request.Id}", cancellationToken);

                return await _mediator.Send(new GetDocumentsForMemberQuery.Request(request.MemberId), cancellationToken);

            }
        }
    }
}