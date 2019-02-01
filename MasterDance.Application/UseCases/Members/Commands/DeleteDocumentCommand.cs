using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Application.Exceptions;
using MasterDance.Application.Infrastructure;
using MasterDance.Application.UseCases.Members.Models;
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

        public class Handler : RequestHandlerBase<Request, ICollection<DocumentModel>> {
            public Handler(MasterDanceDbContext dbContext) : base(dbContext)
            {
            }

            public override async Task<ICollection<DocumentModel>> Handle(Request request, CancellationToken cancellationToken)
            {
                DbContext.Entry(new Document {Id = request.Id}).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync(cancellationToken);

                return await DbContext.Documents.Where(x => x.MemberId == request.MemberId)
                    .Select(Projections.ToDocumentModel())
                    .ToArrayAsync(cancellationToken);

            }
        }
    }
}